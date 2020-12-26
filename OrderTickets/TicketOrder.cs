using System;
using System.Globalization;
using System.Windows.Data;

namespace OrderTickets
{
    enum PrivilegeLevel { Standard, Premium, Executive, PremiumExecutive }

    class TicketOrder
    {
        private string _eventName;
        private string _customerReference;
        private PrivilegeLevel _privilegeLevel;
        private short _numberOfTickets;

        private bool checkPrivilegeAndNumberOfTickets(
            PrivilegeLevel proposedPrivilegeLevel,
            short proposedNumberOfTickets)
        {
            var retVal = false;

            switch (proposedPrivilegeLevel)
            {
                case PrivilegeLevel.Standard:
                    retVal = (proposedNumberOfTickets <= 2);
                    break;

                case PrivilegeLevel.Premium:
                    retVal = (proposedNumberOfTickets <= 4);
                    break;

                case PrivilegeLevel.Executive:
                    retVal = (proposedNumberOfTickets <= 8);
                    break;

                case PrivilegeLevel.PremiumExecutive:
                    retVal = (proposedNumberOfTickets <= 10);
                    break;
            }

            return retVal;
        }

        public override string ToString()
        {
            string formattedString = String.Format("Event: {0}\tCustomer: {1}\tPrivilege: {2}\tTickets: {3}",
                _eventName, _customerReference, 
                _privilegeLevel, _numberOfTickets);
            return formattedString;
        }

        public PrivilegeLevel PrivilegeLevel
        {
            get { return _privilegeLevel; }
            set
            {
                _privilegeLevel = value;
                if (!checkPrivilegeAndNumberOfTickets(value, _numberOfTickets))
                {
                    throw new ApplicationException(
                        "Privilege level too low for this number of tickets");
                }
            }
        }

        public short NumberOfTickets
        {
            get { return _numberOfTickets; }
            set
            {
                _numberOfTickets = value;
                if (!checkPrivilegeAndNumberOfTickets(_privilegeLevel, value))
                {
                    throw new ApplicationException(
                        "Too many tickets for this privilege level");
                }

                if (_numberOfTickets <= 0)
                {
                    throw new ApplicationException(
                        "You must buy at least one ticket");
                }
            }
        }

        public string EventName
        {
            get { return _eventName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException
                        ("Specify an event");
                }
                _eventName = value;
            }
        }
        
        public string CustomerReference
        {
            get { return _customerReference; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException
                        ("Specify the customer reference number");
                }
                _customerReference = value;
            }
        }
    }

    [ValueConversion(typeof(string), typeof(PrivilegeLevel))]
    public class PrivilegeLevelConverter : IValueConverter
    {
        public object  Convert(object value, Type targetType, object parameter, 
                               CultureInfo culture)
        {
         	var privilegeLevel = (PrivilegeLevel)value;
            string convertedPrivilegeLevel = String.Empty;

            switch (privilegeLevel)
            {
                case PrivilegeLevel.Standard:
                    convertedPrivilegeLevel = "Standard";
                    break;

                case PrivilegeLevel.Premium:
                    convertedPrivilegeLevel = "Premium";
                    break;

                case PrivilegeLevel.Executive:
                    convertedPrivilegeLevel = "Executive";
                    break;

                case PrivilegeLevel.PremiumExecutive:
                    convertedPrivilegeLevel = "Premium Executive";
                    break;
            }

            return convertedPrivilegeLevel;
        }

        public object  ConvertBack(object value, Type targetType, object parameter, 
                                   CultureInfo culture)
        {
         	var privilegeLevel = PrivilegeLevel.Standard;

            switch ((string)value)
            {
                case "Standard":
                    privilegeLevel = PrivilegeLevel.Standard;
                    break;

                case "Premium":
                    privilegeLevel = PrivilegeLevel.Premium;
                    break;

                case "Executive":
                    privilegeLevel = PrivilegeLevel.Executive;
                    break;

                case "Premium Executive":
                    privilegeLevel = PrivilegeLevel.PremiumExecutive;
                    break;
            }

            return privilegeLevel;
        }
    }
}
