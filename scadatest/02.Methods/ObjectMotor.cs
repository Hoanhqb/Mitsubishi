using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace scadatest
{
    public class ObjectMotor
    {
        //ini
        PictureBox pic;
        Point Location;
        string filePath;
        string OnfilePath;
        string OfffilePath;
        string warnfilePath;
        int SpeedLow;
        int SpeedHigh;
        int command;
        int warnning;
        int status;
        int width;
        int heigh;
        string description;
        // communication with Form
        public int Command { get => command; set => command = value; }
        public int Warnning { get => warnning; set => warnning = value; }
        public int Status { get => status; set => status = value; }
        public Point Location1 { get => Location; set => Location = value; }
        public string Description { get => description; set => description = value; }
        public int Width { get => width; set => width = value; }
        public int Heigh { get => heigh; set => heigh = value; }
        public string FilePath { get => filePath; set => filePath = value; }
        public string OnfilePath1 { get => OnfilePath; set => OnfilePath = value; }
        public string OfffilePath1 { get => OfffilePath; set => OfffilePath = value; }
        public string WarnfilePath { get => warnfilePath; set => warnfilePath = value; }
        public int SpeedLow1 { get => SpeedLow; set => SpeedLow = value; }
        public int SpeedHigh1 { get => SpeedHigh; set => SpeedHigh = value; }

        // property
        public ObjectMotor(Point Location, int width , int heigh, string FilePath)
        {
            pic = new PictureBox()
            {
                Name = "Motor",//
                Location = Location,// Đặt vị trí mong muốn
                Size = new Size(width, heigh),// Đặt vị trí mong muốn
                Image = Image.FromFile(FilePath),// Đặt vị trí mong muốn
                SizeMode = PictureBoxSizeMode.StretchImage
            };
        }
        //
        // methods
        public void ReadStatusDevice(int Status,int warnning, string PathImageOff, string PathImageOn, string Pathwarning )
        {
            if(Status == 1 )
            {
                pic.Image = Image.FromFile(PathImageOn); // Đặt hình ảnh ở giá trị ON
            }
            else
            {
                pic.Image = Image.FromFile(PathImageOff);// Đặt hình ảnh ở giá trị OFF
            }
            if (warnning == 1)
            {
                pic.Image = Image.FromFile(Pathwarning);//  Đặt hình ảnh ở giá trị Warning
            } 
        }
       
        public int  SetDevice(int Y)  // Đặt giá trị xuống cho YO,
        {
            if (Y == 1) 
            {
                return 1;
            }
            return 0;
        }
        public int ReadSpeedDevice(int X)
        {
            if (X == 1) 
            {
                return 1;
            }
            return 0;
        }
        public int GetSpeedDevice(int Y) 
        {
            if (Y == 1)
            {
                return 1;
            }
            return 0;
        }
    }
}
