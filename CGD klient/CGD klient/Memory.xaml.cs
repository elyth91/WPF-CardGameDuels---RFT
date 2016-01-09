using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace CGD_klient
{
    /// <summary>
    /// Interaction logic for Memory.xaml
    /// </summary>
    public partial class Memory : Window
    {
        List<string> memimg;
        Image[] slots;
        List<card> cards;
        string blank;
        List<card> selected;
        bool started;
        public Memory()
        {
            InitializeComponent();
            started = false;
            string loc = Directory.GetCurrentDirectory() + "\\memory\\";
            memimg = new List<string>() 
            { loc + "alma_1.jpg", loc + "alma_2.jpg", 
              loc + "banán_1.jpg", loc + "banán_2.jpg",
              loc + "barack_1.jpg", loc + "barack_2.jpg",
              loc + "citrom_1.jpg", loc + "citrom_2.jpg",
              loc + "cseresznye_1.jpg", loc + "cseresznye_2.jpg",
              loc + "dinnye_1.jpg", loc + "dinnye_2.jpg",
              loc + "dió_1.jpg", loc + "dió_2.jpg",
            };
            blank = loc + "blank.jpg";
            slots = new Image[]{
                m1,m2,m3,m4,m5,m6,m7,m8,m9,m10,m11,m12,m13,m14
            };
            cards = new List<card>();
            selected = new List<card>();
            Random r = new Random();
            for (int i = 0; i < slots.Length; i++)
            {
                int s = r.Next(0, memimg.Count);
                cards.Add(new card(i, memimg[s], slots[i]));
                memimg.RemoveAt(s);
            }
        }
        void select()
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            started = true;
            foreach (card item in cards)
            {
                item.img.Source = new BitmapImage(new Uri(blank));
            }
        }
        void end()
        {
            MessageBox.Show("Ügyes voltál");
            this.Close();
        }
        private void select(object sender, MouseButtonEventArgs e)
        {
            if (!started) return;
            int i = 0;
            while (!cards[i].img.IsMouseOver)
                i++;
            cards[i].img.Source = new BitmapImage(new Uri(cards[i].source));
            selected.Add(cards[i]);
            cards.RemoveAt(i);
            if (selected.Count==2)
            {
                string[] s0 = selected[0].source.Split('\\');
                string[] s1 = selected[1].source.Split('\\');
                string[] f0 = s0[s0.Length-1].Split('_');
                string[] f1 = s1[s1.Length-1].Split('_');
                Task.Delay(50000);
                if (f0[0]==f1[0])
                {
                    foreach (card item in selected)
                    {
                        item.img.Visibility = Visibility.Hidden;
                    }
                }
                else
                {
                    foreach (card item in selected)
                    {
                        item.img.Source = new BitmapImage(new Uri(blank));
                        cards.Add(item);
                    }
                }
                selected.Clear();
            }
            if (cards.Count==0)
            {
                end();
            }
        }

    }
    class card
    {
        public int index;
        public string source;
        public Image img;
        public card(int index,string source, Image img)
        {
            this.index = index;
            this.img = img;
            this.source = source;
            img.Source = new BitmapImage(new Uri(source));
        }
    }
}
