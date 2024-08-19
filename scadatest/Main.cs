
using System.DirectoryServices.ActiveDirectory;
using System.Windows.Forms;
using ActUtlTypeLib;
using System.Runtime.InteropServices;
using static System.Windows.Forms.DataFormats;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using System.Net;
using System.Threading;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Diagnostics;
using System.Security.Principal;
using Timer = System.Windows.Forms.Timer;
using scadatest.DatabasePLC;


namespace scadatest
{
    public partial class Main : Form
    {
        //
        #region ini
        Form login = new Login();
        Form form2;
        ActUtlType plc = new ActUtlType();

        private Point _endPosition;
        private PictureBox _pictureBox;
        // private System.Windows.Forms.Timer _timer;
        private int _speed = 4; // Tốc độ di chuyển của PictureBox, có thể điều chỉnh
        //
        // timer
        Timer timer1 = new Timer();
        Timer timerLift = new Timer();
        private static System.Threading.Timer _timer;
        //Vị trí
      
        bool isPlConnecting = false;
        private bool isDisposed = false;
        string url = @"C:\Users\hoanh\source\repos\UpdateDataPLC\UpdateDataPLC\bin\Debug\net8.0-windows\";
        // Vi tri ban dau Move1
        #region PosisionMove
        // move 1
        Point move1Ps1;
        Point move1Ps2;
      
        // move 2
        Point move2Ps1;
        Point move2Ps2;
        // move 3
        Point move3Ps1;
        Point move3Ps2;
        // move 4
        Point move4Ps1;
        Point move4Ps2;

        // thang len
        Point ThanglenPs1;
        Point ThanglenPs2;
        // thang xuong
        Point ThangxuongPs1;
        Point ThangxuongPs2;
        // Ps0  Line 1
        Point PsL1Ps0; // original possion of object
        Point PsL1Ps1;
        Point PsL1Ps1_1; // original possion of object_1
        Point PsL1Ps2;
        Point PsL1Ps2_1; // original possion of object_
        Point PsL1Ps3;
        Point PsL1Ps3_1; // original possion of object_

        Point PsL1Ps4;
        Point PsL1Ps4_1; // original possion of object_
        Point PsL1Ps5;
        Point PsL1Ps5_1; // original possion of object_

        #endregion
        //
        private int previousPLCY000 = -1;
        private int previousPLCY001 = -1;
        //
        #region variablePLC
        bool test = false;
        int count = 0;

        int PLCX000 = -1;
        int PLCX001 = -1;
        int PLCX002 = -1;
        int PLCX003 = -1;
        int PLCX004 = -1;
        int PLCX005 = -1;
        int PLCX006 = -1;
        int PLCX007 = -1;
        int PLCX010 = -1;
        int PLCX011 = -1;
        int PLCX012 = -1;
        int PLCX013 = -1;
        // 
        int PLCY000 = -1;
        int PLCY001 = -1;
        int PLCY002 = -1;
        int PLCY003 = -1;
        int PLCY004 = -1;
        int PLCY005 = -1;
        int PLCY006 = -1;
        int PLCY007 = -1;
        int PLCY010 = -1;
        int PLCY011 = -1;
        int PLCY012 = -1;
        int PLCY013 = -1;

        #endregion
        #endregion
        public Main()

        {
            InitializeComponent();
            //database
            CreatePossion();
            url = @databaseUrl.Text;
                //
            // this.DoubleBuffered = true;
            Move1chaylen = -1;
            // Khởi tạo vị trí ban đầu ở đây
            // đưa table lên top
            picLift1table.BringToFront();
            //picLift2table1.BringToFront();
         
         
            // Đồ Họa Ban đầu ở đây
            #region Graphic
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            panelNav.Height = btnMenuHome.Height;
            panelNav.Top = btnMenuHome.Top;
            panelNav.Left = btnMenuHome.Left;
            btnMenuHome.BackColor = Color.FromArgb(46, 51, 73);
            #endregion

            // Khởi tạo timer ở đây
            #region Timer
            timer1.Interval = 10;
            timer1.Tick += Timer1_Tick1;


            timerLift.Interval = 500;
            timerLift.Tick += TimerLift_Tick1;
            // timerLift.Start();
            // Khoi tao timer UpdatePLC o day
            _timer = new System.Threading.Timer(TimerCallback, null, 0, 1000);

            #endregion

        }
        // Khởi tạo vị trí ban đầu
        private void CreatePossion()
        {
            #region KhoiTaoViTriBanDau
            // tạo vị trí ban đầu cho move1
            move1Ps1 = groupBoxMove1.Location;
            move1Ps2 = new Point(move1Ps1.X, move1Ps1.Y - 50);
            // tạo vị trí ban đầu cho move2
            move2Ps1 = groupBoxMove2.Location;
            move2Ps2 = new Point(move2Ps1.X, move2Ps1.Y - 50);
            // tạo vị trí ban đầu cho move3
            move3Ps1 = groupBoxMove3.Location;
            move3Ps2 = new Point(move3Ps1.X, move3Ps1.Y - 50);
            // tạo vị trí ban đầu cho move34
            move4Ps1 = groupBoxMove4.Location;
            move4Ps2 = new Point(move4Ps1.X, move4Ps1.Y - 50);

            // tao vị trí ban đầu cho thang xuống 1
            ThangxuongPs1 = groupCarryLift2Move.Location; // vị trí ban đầu thành move
            ThangxuongPs2 = groupCarryLift2PsF3.Location; // vị trí tầng trên
            // tao vị trí ban đầu cho thang lên 1
            ThanglenPs1 = groupCarryLift1Move.Location; // vị trí ban đầu thành move
            ThanglenPs2 = groupCarryLift1PsF3.Location; // vị trí tầng trên
                                                        // tạo vị trí ban đâu cho Line 1 vị trí 0.
            PropertyLine.Ps0Start = picL1_0.Location;
            PropertyLine.Ps0End = picL1_1.Location;
            PropertyLine.Ps1Start = picL1_0.Location;
            PropertyLine.Ps1End = picL1_2.Location;
            #endregion
        }
        // xử lý đọc database
        private string readdata(string filePath)
        {

            if (File.Exists(filePath))
            {
                Console.WriteLine("File exists.");
                // Bạn có thể thực hiện các thao tác khác trên file ở đây
                string content = File.ReadAllText(filePath);
                return content;
            }
            return null;
        }
        #region Data PLC
        string dataY0;
        string dataY1;
        string dataY2;
        string dataY3;
        string dataY4;
        string dataY5;
        string dataY6;
        string dataY7;
        string dataY1087;

        //X
        string dataX0;
        string dataX1;
        string dataX2;
        string dataX3;
        string dataX4;
        string dataX5;
        string dataX6;
        string dataX7;
        // X 
        string dataX1084A;
        string dataX1055;
        string dataX1058;
        string dataX1085E;
        #endregion

        private void TimerCallback(object state)
        {
            //Read data Y from PLC
            dataY0 = readdata(url + "dataY0.txt");
            dataY1 = readdata(url + "dataY1.txt");
            dataY2 = readdata(url + "dataY2.txt");
            dataY3 = readdata(url + "dataY3.txt");
            dataY4 = readdata(url + "dataY4.txt");
            dataY5 = readdata(url + "dataY5.txt");
            dataY6 = readdata(url + "dataY6.txt");
            dataY7 = readdata(url + "dataY7.txt");
            dataY1087 = readdata(url + "dataY1087.txt");
            //Read data X from PLC
            dataX0 = readdata(url + "dataX0.txt");
            dataX1 = readdata(url + "dataX1.txt");
            dataX2 = readdata(url + "dataX2.txt");
            dataX3 = readdata(url + "dataX3.txt");
            dataX4 = readdata(url + "dataX4.txt");
            dataX5 = readdata(url + "dataX5.txt");
            dataX6 = readdata(url + "dataX6.txt");
            dataX7 = readdata(url + "dataX7.txt");
            dataX1084A = readdata(url + "dataX1084A.txt");

        }
        bool connected1 = false;
        bool lock1 = false;
        bool lock2 = false;
        bool lock3 = false;
        // timer di chuyen
        private async void Timer1_Tick1(object? sender, EventArgs e)
        {
            // Move lift1
            if (dataY2 == "1")
            {

                Move(groupCarryLift2Move, groupCarryLift2PsF3.Location, timer1);
            }
            if (dataY3 == "1")
            {

                Move(groupCarryLift2Move, ThangxuongPs1, timer1);
            }

            if (dataY0 == "1")
            {

                Move(groupCarryLift1Move, groupCarryLift1PsF3.Location, timer1);
            }
            if (dataY1 == "1")
            {

                Move(groupCarryLift1Move, ThanglenPs1, timer1);
            }
            // Visiable Item
            if (dataX0 == "1")
            {
                picLift1item1.Visible = true;
                picLift1item2.Visible = true;
            }
            else
            {
                picLift1item1.Visible = false;
                picLift1item2.Visible = false;
            }
            // lift2
            if (dataX2 == "1")
            {
                picLift2item1.Visible = true;
                picLift2item2.Visible = true;
            }
            else
            {
                picLift2item1.Visible = false;
                picLift2item2.Visible = false;
            }
            // Move1
            ChayQuaLai(groupBoxMove1, move1Ps1, move1Ps2, Move1Item1, Move1Item2, dataY4, dataY5, dataX4, dataX5,timer1);
            //Move2
            ChayQuaLai(groupBoxMove2, move2Ps1, move2Ps2, Move2Item1, Move2Item2, dataY6, dataY7, dataX6, dataX7, timer1);
            // Line
            MoveLine(picL1_0, PropertyLine.Ps0Start, PropertyLine.Ps0End, dataX1084A, dataY1087, timer1);

        }
        // Function MoveItem Line 1
        private void MoveLine(PictureBox picLine, Point viTriBanDau, Point viTriKetThuc, string readDatabase, string writeDabase, System.Windows.Forms.Timer timer)
        {
            //Move from A to B.
            if(readDatabase == "1")
            {
                // unhide Pictrurebox
                picLine.Visible = true; 
                // Move from A to B when called moving.
                if(writeDabase == "1")
                {
                    MoveP(picLine, viTriKetThuc, timer1);
                }
            }
            else
            {
                // return it to its original possion when no command is given.
                picLine.Location = viTriBanDau;
                picLine.Visible = false; // hide 
            }
           
        }
        // Function Move
        private void ChayQuaLai(GroupBox doiTuong_diChuyen,
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
        private void TimerTest_Tick(object? sender, EventArgs e)
        {


        }
        private void Timer_Tick(object? sender, EventArgs e)
        {

        }


        private async void TimerLift_Tick1(object? sender, EventArgs e)
        {


        }
        // xử lý lên xuống Move ở đây

        private void TimerLift_Tick(object? sender, EventArgs e)
        {
        }

        public Main(Login form2)
        {
            InitializeComponent();
            this.form2 = form2; // Lưu tham chiếu của Form1
        }

        private void Form1_FormClosed(object? sender, FormClosedEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }
        // Xử lý đồ họa trong này
        #region Graphic
        // đồ họa
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
        int nLeftRect,
        int nTopRect,
        int nRightRect,
        int nBottomRect,
        int nWidthEllipse,
        int nHeightEllipse
    );

        private void btnMenuHome_Click(object sender, EventArgs e)
        {
            panelNav.Height = btnMenuHome.Height;
            panelNav.Top = btnMenuHome.Top;
            panelNav.Left = btnMenuHome.Left;
            btnMenuHome.BackColor = Color.FromArgb(46, 51, 73);

        }

        private void btnMenuAnalysis_Click(object sender, EventArgs e)
        {
            panelNav.Height = btnMenuAnalysis.Height;
            panelNav.Top = btnMenuAnalysis.Top;
            panelNav.Left = btnMenuAnalysis.Left;
            btnMenuAnalysis.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnMenuReport_Click(object sender, EventArgs e)
        {
            panelNav.Height = btnMenuReport.Height;
            panelNav.Top = btnMenuReport.Top;
            panelNav.Left = btnMenuReport.Left;
            btnMenuReport.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnMenuConnect_Click(object sender, EventArgs e)
        {
            panelNav.Height = btnMenuConnect.Height;
            panelNav.Top = btnMenuConnect.Top;
            panelNav.Left = btnMenuConnect.Left;
            btnMenuConnect.BackColor = Color.FromArgb(46, 51, 73);
            // open btn connect
            // Thiết lập đường dẫn tới ứng dụng cần chạy với quyền admin
            string filePath = @"C:\Users\hoanh\source\repos\UpdateDataPLC\UpdateDataPLC\bin\Debug\net8.0-windows\UpdateDataPLC.exe";

            if (!RunningAsAdmin())
            {
                Console.WriteLine("Running as admin required!");
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.UseShellExecute = true;
                proc.WorkingDirectory = Environment.CurrentDirectory;
                proc.FileName = filePath;
                proc.Verb = "runas";
                try
                {
                    Process.Start(proc);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("This program must be run as an administrator! \n\n" + ex.ToString());

                }
            }
        }
        private static bool RunningAsAdmin()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(id);

            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
        private void btnMenuSetting_Click(object sender, EventArgs e)
        {
            panelNav.Height = btnMenuSetting.Height;
            panelNav.Top = btnMenuSetting.Top;
            panelNav.Left = btnMenuSetting.Left;
            btnMenuSetting.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnMenuHome_Leave(object sender, EventArgs e)
        {
            btnMenuHome.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnMenuAnalysis_Leave(object sender, EventArgs e)
        {
            btnMenuAnalysis.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnMenuReport_Leave(object sender, EventArgs e)
        {
            btnMenuReport.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnMenuConnect_Leave(object sender, EventArgs e)
        {
            btnMenuConnect.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnMenuSetting_Leave(object sender, EventArgs e)
        {
            btnMenuSetting.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int count1 = 0;
        private void btnfullfill_Click(object sender, EventArgs e)
        {
            if (count1 == 0)
            {
                this.WindowState = FormWindowState.Maximized;
                count1 = 1;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }


        }
        #endregion
        int i = 0;
        bool checklift = false;
        private  void btn_Start_Click(object sender, EventArgs e)
        {
            checklift = true;
        }
        public void Move(GroupBox PictureBox, Point Endpoint, Timer timerN)
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
        public void MoveP(PictureBox PictureBox, Point Endpoint, System.Windows.Forms.Timer timerN)
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

        public async Task MoveAsync(GroupBox pictureBox, Point endpoint, System.Windows.Forms.Timer timer)
        {
            Point startPosition = new Point(pictureBox.Location.X, pictureBox.Location.Y); // Vị trí A
            Point endPosition = endpoint; // Vị trí B

            while (pictureBox.Location != endPosition)
            {
                Point currentPosition = pictureBox.Location;

                // Move horizontally
                if (currentPosition.X < endPosition.X)
                {
                    currentPosition.X += 1;
                }
                else if (currentPosition.X > endPosition.X)
                {
                    currentPosition.X -= 1;
                }

                // Move vertically
                if (currentPosition.Y < endPosition.Y)
                {
                    currentPosition.Y += 1;
                }
                else if (currentPosition.Y > endPosition.Y)
                {
                    currentPosition.Y -= 1;
                }

                pictureBox.Location = currentPosition;

                // Delay to make the movement smooth
                await Task.Delay(10); // Adjust delay as needed
            }

            // Optionally stop the timer if needed
            //  timer.Stop();
        }

        private void pictureBox38_Click(object sender, EventArgs e)
        {

        }
        private void picMS1_Click(object sender, EventArgs e)
        {
        }
        int Ms = 0;
        private void picMS2_Click(object sender, EventArgs e)
        {
            Ms = 2;
            //PicItemM2.Visible = true;
        }

        bool connected = false;

        private void btnConnect_Click(object sender, EventArgs e)
        {
            timer1.Start();
            richTextBoxKetNoi.Text = "Chế Độ Auto";
            btnConnect.Enabled = false; btnDisconnect.Enabled = true;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;

        }

        private void btnMinisize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        bool isAuto = false;
        private void btnAutoMode_Click(object sender, EventArgs e)
        {
            isAuto = true;
            richTextBoxDieukhien.Text = "Chế độ tự động thiết lập";
            btnAutoMode.BackColor = Color.Green;

        }
        bool isTay = false;

        private void BtnDangXuat_Click(object sender, EventArgs e)
        {


            // this.Hide();
            if (form2 == null || form2.Disposing)
            {
                form2 = new Login();

            }
            // form2.Show(); // Hiển thị lại Form1 thay vì tạo mới
            form2.ShowDialog();
        }


        string data;

        int Move1chaylen;
        int Move1chayve = 0;
        private void checkchayve_CheckedChanged(object sender, EventArgs e)
        {
            Move1chayve = Move1chayve == 1 ? 0 : 1;

        }

        private void checkChaylen_CheckedChanged(object sender, EventArgs e)
        {
            Move1chaylen = Move1chaylen == 1 ? 0 : 1;

        }

        private void button2_Click(object sender, EventArgs e)
        {


        }
        int Move2chaylen = 0;
        int Move2chayve = 0;
        private void checkChaylenM2_CheckedChanged(object sender, EventArgs e)
        {
            Move2chaylen = Move2chaylen == 1 ? 0 : 1;
        }

        private void checkChayveM2_CheckedChanged(object sender, EventArgs e)
        {
            Move2chayve = Move2chayve == 1 ? 0 : 1;
        }
        int MoveThanglenlenTable = 0;
        int MoveThanglenxuongTable = 0;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            MoveThanglenlenTable = MoveThanglenlenTable == 1 ? 0 : 1;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            MoveThanglenxuongTable = MoveThanglenxuongTable == 1 ? 0 : 1;
        }

        int MoveThangxuonglenTable = 0;
        int MoveThangxuongxuongTable = 0;
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

            MoveThangxuonglenTable = MoveThangxuonglenTable == 1 ? 0 : 1;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            MoveThangxuongxuongTable = MoveThangxuongxuongTable == 1 ? 0 : 1;
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Dispose();
            timerLift.Dispose();

            plc.Close();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
    

