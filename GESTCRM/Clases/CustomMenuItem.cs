using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GESTCRM.Clases
{
    class CustomMenuItem : MenuItem
    {
        private Font _font;
        public Font Font
        {
            get
            {
                return _font;
            }
            set
            {
                _font = value;
            }
        }

        public CustomMenuItem()
        {
            this.OwnerDraw = true;
            //this.Font = SystemFonts.DefaultFont; //---- GSG (13/03/2019)
            this.Font = new System.Drawing.Font("Verdana", 12F); 
        }

        public CustomMenuItem(string text)
            : this()
        {
            this.Text = text;
        }

        // ... Add other constructor overrides as needed

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            // I would've used a Graphics.FromHwnd(this.Handle) here instead,
            // but for some reason I always get an OutOfMemoryException,
            // so I've fallen back to TextRenderer

            var size = TextRenderer.MeasureText(this.Text, this.Font);
            e.ItemWidth = (int)size.Width;
            e.ItemHeight = (int)size.Height;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            //e.DrawBackground(); //No  vull que pinti el fons
            e.Graphics.DrawString(this.Text, this.Font, Brushes.Black, e.Bounds); // La poso negra
        }
    }
}