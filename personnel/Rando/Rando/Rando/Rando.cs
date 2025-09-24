using Gpx;
using System.Reflection.PortableExecutable;

namespace Rando
{
    public partial class Rando : Form
    {
        private List<Trackpoint> trackpoints = new List<Trackpoint>();

        public Rando()
        {
            InitializeComponent();
        }

        private void Rando_Form_Paint(object sender, PaintEventArgs e)
        {
            const double LAT_OFFSET = 46.39;
            const double LONG_OFFSET = 7.61;

            Pen myPen = new Pen(Color.Red);
            myPen.Width = 2;

            Console.WriteLine("Winodw Size" + this.Width + " x " + this.Height);
            Console.WriteLine("All points : " + String.Join(", ", trackpoints));
            Point[] points = trackpoints.Select(tp => new Point((int)Math.Round((tp.Longitude - LONG_OFFSET) * 10000), this.ClientRectangle.Height - (int)Math.Round((tp.Latitude - LAT_OFFSET) * 10000))).ToArray();
            Console.WriteLine("All points : " + String.Join(", ", points));
            this.CreateGraphics().DrawLines(myPen, points);
        }

        private void Rando_Load(object sender, EventArgs e)
        {
            const string FILE_NAME = "C:\\Users\\pw57drg\\Documents\\GitHub\\323-Programmation_fonctionnelle\\personnel\\Rando\\gpx\\gemmikandersteg.gpx";
            using (GpxReader reader = new GpxReader(File.OpenRead(FILE_NAME)))
            {
                while (reader.Read())
                {
                    if (reader.ObjectType == GpxObjectType.Track)
                    {
                        trackpoints = reader.Track.Segments[0].TrackPoints.Select((x) => new Trackpoint()
                        {
                            Latitude = x.Latitude,
                            Longitude = x.Longitude,
                            Elevation = x.Elevation,
                        }).ToList();
                    }
                    Console.WriteLine("Load trackpoints OK");

                }
            }

            Console.WriteLine(trackpoints.Count);



        }
    }
}
