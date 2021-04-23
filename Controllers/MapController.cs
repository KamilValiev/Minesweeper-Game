using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sapper.Controllers
{
    public static class MapController
    {
        public const int mapSize = 8;
        public const int cellSize = 50;

        public static int[,] map = new int[mapSize, mapSize];
        public static Button[,] buttons = new Button[mapSize, mapSize];


        public static Image spriteSet;

        public static void Init(Form current)
        {
            spriteSet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\tiles.png"));
            ConfigureMapSize(current);
            InitMap();
            InitButtons(current);
        }

        private static void ConfigureMapSize(Form current)
        {
            current.Width = mapSize * cellSize + 16;
            current.Height = (mapSize + 1) * cellSize - 11;
        }

        private static void InitMap()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    map[i, j] = 0;
                }
            }
        }

        private static void InitButtons(Form current)
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    Button cell = new Button();
                    cell.Location = new Point(j * cellSize, i * cellSize);
                    cell.Size = new Size(cellSize, cellSize);
                    cell.Image = FindNeededImage(0, 0);
                    current.Controls.Add(cell);
                    buttons[i, j] = cell;
                }
            }
        }

        public static Image FindNeededImage(int xPos, int yPos)
        {
            Image image = new Bitmap(cellSize, cellSize);
            Graphics g = Graphics.FromImage(image);
            g.DrawImage(spriteSet, new Rectangle(new Point(0, 0), new Size(cellSize, cellSize)), 0 + 32 * xPos, 0 + 32 * yPos, 33, 33, GraphicsUnit.Pixel);


            return image;
        }
    }
}
