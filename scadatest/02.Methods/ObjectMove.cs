using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace scadatest
{
    public class ObjectMove
    {
        #region Fields
        GroupBox doiTuong_diChuyen;
        Point viTri_banDau;
        Point viTri_ketThuc;
        PictureBox doiTuong_Hang1;
        PictureBox doiTuong_Hang2;
        string dieuKhienToi;
        string dieuKhienVe;
        string kichHangVitri1;
        string kichHangVitri2;
        System.Windows.Forms.Timer timer1;
        #endregion
        #region Properties


        public GroupBox DoiTuong_diChuyen { get => doiTuong_diChuyen; set => doiTuong_diChuyen = value; }
        public Point ViTri_banDau { get => viTri_banDau; set => viTri_banDau = value; }
        public Point ViTri_ketThuc { get => viTri_ketThuc; set => viTri_ketThuc = value; }
        public PictureBox DoiTuong_Hang1 { get => doiTuong_Hang1; set => doiTuong_Hang1 = value; }
        public PictureBox DoiTuong_Hang2 { get => doiTuong_Hang2; set => doiTuong_Hang2 = value; }
        public string DieuKhienToi { get => dieuKhienToi; set => dieuKhienToi = value; }
        public string DieuKhienVe { get => dieuKhienVe; set => dieuKhienVe = value; }
        public string KichHangVitri1 { get => kichHangVitri1; set => kichHangVitri1 = value; }
        public string KichHangVitri2 { get => kichHangVitri2; set => kichHangVitri2 = value; }
        public System.Windows.Forms.Timer Timer1 { get => timer1; set => timer1 = value; }

        public ObjectMove() { }
        #endregion
        #region Methods

        public void ChayQuaLai(GroupBox doiTuong_diChuyen,
             Point viTri_banDau, Point viTri_ketThuc,
             PictureBox doiTuong_Hang1, PictureBox doiTuong_Hang2,
             string dieuKhienToi, string dieuKhienVe, string kichHangVitri1, string kichHangVitri2
             , System.Windows.Forms.Timer timer1)
        {
            // Điều khiển Move
            if (dieuKhienToi == "1")
            {
                // điều khiển tới
                Move(doiTuong_diChuyen, viTri_ketThuc, timer1);
            }
            if (dieuKhienVe == "1")
            {
                // điều khiển về
                Move(doiTuong_diChuyen, viTri_banDau, timer1);
            }
            //Ẩn hiện item1
            if (kichHangVitri1 == "1")
            { // Hiện Hàng 1
                doiTuong_Hang1.Visible = true;
            }
            else
            {
                // Ẩn Hàng 1
                doiTuong_Hang1.Visible = false;
            }
            // item2
            if (kichHangVitri2 == "1")
            {
                // Hiện Hàng 2
                doiTuong_Hang2.Visible = true;
            }
            else
            {
                // Ẩn Hàng 2
                doiTuong_Hang2.Visible = false;
            }
        }
        public void Move(GroupBox PictureBox, Point Endpoint, System.Windows.Forms.Timer timerN)
        {

            Point startPosition = new Point(PictureBox.Location.X, PictureBox.Location.Y); // Vị trí A
            Point endPosition = Endpoint; // Vị trí B
            Point currentPosition = PictureBox.Location;

            if (currentPosition.X < endPosition.X)
            {
                currentPosition.X += 1;
            }
            else if (currentPosition.X > endPosition.X)
            {
                currentPosition.X -= 1;
            }

            if (currentPosition.Y < endPosition.Y)
            {
                currentPosition.Y += 1;
            }
            else if (currentPosition.Y > endPosition.Y)
            {
                currentPosition.Y -= 1;
            }

            PictureBox.Location = currentPosition;


            if (currentPosition == endPosition)
            {



            }
        }
        #endregion
    }


}
