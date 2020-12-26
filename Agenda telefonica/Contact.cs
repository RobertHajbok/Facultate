using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agenda_telefonica
{
    public class Contact
    {
        public string name;
        public string number;
        public System.Drawing.Image image;
        public string imgSrc = "";

        public Contact(string name_, string number_, string imgSrc_)
        {
            imgSrc = imgSrc_;
            name = name_;
            number = number_;
            if (imgSrc == "NA")
            {
                image = System.Drawing.Image.FromFile(appEngine.image);
                imgSrc = appEngine.image;
            }
            else
            {
                bool ok = false;
                foreach (char c in imgSrc)
                    if (c == ':')
                        ok = true;
                if (!ok)
                {
                    if (imgSrc != "N/A")
                        image = System.Drawing.Image.FromFile(@"...\...\Image\" + imgSrc);
                }
                else
                    if (imgSrc != "N/A")
                        image = System.Drawing.Image.FromFile(imgSrc);
            }
        }
    }
}
