using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskinApi.DAL
{
    class CircularButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath grp = new GraphicsPath();
            grp.AddEllipse(0,0,ClientSize.Width,ClientSize.Height);
            this.Region = new Region(grp);  
            base.OnPaint(pevent);   
        }
    }
}
