using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<Image> qiang = new List<Image>();
        List<Image> box = new List<Image>();
        List<Image> mubiao = new List<Image>();

      
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mubiao.Add(image32);
            mubiao.Add(image30);
            mubiao.Add(image28);
            mubiao.Add(image29);
          
            Canvas.SetZIndex(image30,1);
            Canvas.SetZIndex(image32, 1);
            Canvas.SetZIndex(image28, 1);
            Canvas.SetZIndex(image29, 1);
            Canvas.SetZIndex(people, 2);

            people.Tag = "D";
            qiang.Add(image1);
            image1.Tag = "1";
            qiang.Add(image2);
            image2.Tag = "2";
            qiang.Add(image3);
            image3.Tag = "3";
            qiang.Add(image4);
            image4.Tag = "4";
            qiang.Add(image5);
            image5.Tag = "5";
            qiang.Add(image6);
            image6.Tag = "6";
            qiang.Add(image7);
            image7.Tag = "7";
            qiang.Add(image8);
            image8.Tag = "8";
            qiang.Add(image9);
            image9.Tag = "9";
            qiang.Add(image10);
            image10.Tag = "10";
            qiang.Add(image11);
            image11.Tag = "11";
            qiang.Add(image12);
            image12.Tag = "12";
            qiang.Add(image13);
            image13.Tag = "13";
            qiang.Add(image14);
            image14.Tag = "14";
            qiang.Add(image15);
            image15.Tag = "15";
            qiang.Add(image16);
            image16.Tag = "16";
            qiang.Add(image17);
            image17.Tag = "17";
            qiang.Add(image18);
            image18.Tag = "18";
            qiang.Add(image19);
            image19.Tag = "19";
            qiang.Add(image20);
            image20.Tag = "20";
            qiang.Add(image21);
            image21.Tag = "21";
            qiang.Add(image22);
            image22.Tag = "22";
            qiang.Add(image23);
            image23.Tag = "23";
            qiang.Add(image24);
            image24.Tag = "24";
            qiang.Add(image25);
            image25.Tag = "25";
            qiang.Add(image26);
            image26.Tag = "26";
            qiang.Add(image27);
            image27.Tag = "27";

            box.Add(image34);
            box.Add(image35); 
            box.Add(image36); 
            box.Add(image38);
        }

        void dtpq_Tick(object sender, EventArgs e)
        {
           
            
        }



        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
           // people.Tag = "D";
            if (e.Key == Key.A || e.Key == Key.D || e.Key == Key.W || e.Key == Key.S)
            {
                people.Tag = e.Key.ToString();
                for (int i = 0; i < qiang.Count; i++)
                {
                   ///人和墙之间的判断
                    if (people.Tag.ToString() == "W" && Canvas.GetLeft(qiang[i]) == Canvas.GetLeft(people) && Canvas.GetTop(qiang[i]) + qiang[i].Height == Canvas.GetTop(people))
                    {                      
                        return;
                    }                  
                        if (   people.Tag.ToString() == "A" && Canvas.GetLeft(qiang[i]) + qiang[i].Width == Canvas.GetLeft(people) && Canvas.GetTop(qiang[i]) == Canvas.GetTop(people))
                        {                           
                            return;
                        }
                        if (people.Tag.ToString() == "D" && Canvas.GetLeft(qiang[i])  == Canvas.GetLeft(people) +people.Width && Canvas.GetTop(qiang[i]) == Canvas.GetTop(people))
                        {                          
                            return;
                        }
                        if (people.Tag.ToString() == "S" && Canvas.GetLeft(qiang[i])== Canvas.GetLeft(people) && Canvas.GetTop(qiang[i]) == Canvas.GetTop(people)+people.Height)
                        {                            
                            return;
                        }
                }
               // 人和箱子之间的判断

                //上移的判断
                for (int i = 0; i < box.Count; i++)
                {
                    if (people.Tag.ToString() == "W" && Canvas.GetLeft(box[i]) == Canvas.GetLeft(people) && Canvas.GetTop(box[i]) + box[i].Height == Canvas.GetTop(people))
                    {                                           
                        for (int n = 0; n < qiang.Count; n++)
                        {
                            if ( Canvas.GetLeft(qiang[n])==Canvas.GetLeft(people )&&Canvas.GetTop(qiang[n])<Canvas.GetTop(people) )
                            {
                                if (Canvas.GetTop(people)- box[i].Height > Canvas.GetTop(qiang[n]) + qiang[n].Height)
                                {
                                    for (int m = 0; m < box.Count; m++)
                                    {
                                        if (    Canvas.GetLeft(box[m])==Canvas.GetLeft(box[i])&&Canvas.GetTop(box[m]) + box[m].Height == Canvas.GetTop(box[i]))
                                        {
                                            return;

                                        }
                                    }
                                    Canvas.SetTop(box[i], Canvas.GetTop(box[i]) - box[i].Height);
                                    Canvas.SetTop(people, Canvas.GetTop(people) - people.Height);

                                    return;
                                }
                              
                            }
                            if (Canvas.GetLeft(qiang[n]) == Canvas.GetLeft(people) && Canvas.GetTop(people) == Canvas.GetTop(qiang[n]) + qiang[n].Height + box[i].Height)
                            {
                                return;
                            }
                        }
              
                    }

                }
                //下移的判断
                for (int i = 0; i < box.Count; i++)
                {
                    if (people.Tag.ToString() == "S" && Canvas.GetLeft(box[i]) == Canvas.GetLeft(people) && Canvas.GetTop(box[i]) == Canvas.GetTop(people) + people.Height)
                    {
                        for (int n = 0; n < qiang.Count; n++)
                        {
                            if (Canvas.GetLeft(qiang[n]) == Canvas.GetLeft(people) && Canvas.GetTop(qiang[n]) > Canvas.GetTop(people) )
                            {
                                if (   Canvas.GetTop(people) + people.Height + box[i].Height < Canvas.GetTop(qiang[n])  )
                                {
                                    for (int m = 0; m < box.Count; m++)
                                    {
                                        if (Canvas.GetLeft(box[m]) == Canvas.GetLeft(box[i]) && Canvas.GetTop(box[m]) == Canvas.GetTop(box[i]) + box[i].Height)
                                        {
                                            return;

                                        }
                                    }
                                    Canvas.SetTop(box[i], Canvas.GetTop(box[i]) + box[i].Height);
                                    Canvas.SetTop(people, Canvas.GetTop(people) + people.Height);
                                    return;
                                }                                               
                            }
                            if (Canvas.GetTop(people) + people.Height + box[i].Height == Canvas.GetTop(qiang[n]) && Canvas.GetLeft(qiang[n]) == Canvas.GetLeft(people))
                            {
                               return;                            
                            }
                        }
                      
                    }

                }
            
                //left
                   for (int i = 0; i < box.Count; i++)
                {
                    if (people.Tag.ToString() == "A" && Canvas.GetTop(box[i]) == Canvas.GetTop(people) && Canvas.GetLeft(box[i]) + box[i].Width == Canvas.GetLeft(people))
                    {                                           
                        for (int n = 0; n < qiang.Count; n++)
                        {
                            if ( Canvas.GetTop(qiang[n])==Canvas.GetTop(people )&&Canvas.GetLeft(qiang[n])<Canvas.GetLeft(people) )
                            {
                                if (Canvas.GetLeft(people)- box[i].Width > Canvas.GetLeft(qiang[n]) + qiang[n].Width)
                                {
                                    for (int m = 0; m < box.Count; m++)
                                    {
                                        if (Canvas.GetTop(box[m]) == Canvas.GetTop(box[i]) && Canvas.GetLeft(box[m]) + box[m].Width == Canvas.GetLeft(box[i]))
                                        {
                                            return;

                                        }
                                    }
                                    
                                    Canvas.SetLeft(box[i], Canvas.GetLeft(box[i]) - box[i].Width);
                                    Canvas.SetLeft(people, Canvas.GetLeft(people) - people.Width);
                                    return;
                                }
                              
                            }
                            if (Canvas.GetTop(qiang[n]) == Canvas.GetTop(people) && Canvas.GetLeft(people) == Canvas.GetLeft(qiang[n]) + qiang[n].Width + box[i].Width && Canvas.GetLeft(qiang[n]) < Canvas.GetLeft(people))
                            {
                                return;
                            }
                        }
              
                    }

                }
                //right
                   for (int i = 0; i < box.Count; i++)
                   {
                       if (people.Tag.ToString() == "D" && Canvas.GetTop(box[i]) == Canvas.GetTop(people) && Canvas.GetLeft(box[i])== Canvas.GetLeft(people)+people.Width)
                       {
                           for (int n = 0; n < qiang.Count; n++)
                           {
                               if (Canvas.GetTop(qiang[n]) == Canvas.GetTop(people) && Canvas.GetLeft(qiang[n]) > Canvas.GetLeft(people))
                               {
                                   if (Canvas.GetLeft(people) + box[i].Width+people.Width < Canvas.GetLeft(qiang[n]))
                                   {
                                       for (int m = 0; m < box.Count; m++)
                                       {
                                           if (Canvas.GetTop(box[m]) == Canvas.GetTop(box[i])&&Canvas.GetLeft(box[i]) + box[i].Width == Canvas.GetLeft(box[m]))
                                           {
                                               return;

                                           }
                                       }
                                       Canvas.SetLeft(box[i], Canvas.GetLeft(box[i]) + box[i].Width);
                                       Canvas.SetLeft(people, Canvas.GetLeft(people) + people.Width);
                                       return;
                                   }

                               }
                               if (Canvas.GetTop(qiang[n]) == Canvas.GetTop(people) && Canvas.GetLeft(people) + box[i].Width + people.Width == Canvas.GetLeft(qiang[n]) && Canvas.GetLeft(qiang[n]) > Canvas.GetLeft(people))
                               {
                                   return;
                               }
                           }

                       }

                   }
                   //if (true)
                   //{

                   //    for (int i = 0; i < box.Count; i++)
                   //    {
                   //        for (int m = 0; m < mubiao.Count; m++)
                   //        {
                   //            if (Canvas.GetLeft(mubiao[m]) == Canvas.GetLeft(box[i]) && Canvas.GetTop(mubiao[m]) == Canvas.GetTop(box[i]))
                   //            {

                   //            }

                   //        }              
                   //    }
                   //    MessageBox.Show("Good Job!");
                   //}



                switch (people.Tag.ToString())
                {
                    case "A":
                        Canvas.SetLeft(people, Canvas.GetLeft(people) - people.Width);
                        break;
                    case "D":
                        Canvas.SetLeft(people, Canvas.GetLeft(people) + people.Width);
                        break;
                    case "W":
                        Canvas.SetTop(people, Canvas.GetTop(people) - people.Height);
                        break;
                    case "S":
                        Canvas.SetTop(people, Canvas.GetTop(people) + people.Height);
                        break;
                }
                
            }
        }
    }
}
