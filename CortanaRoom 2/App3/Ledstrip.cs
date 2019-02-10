using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoRGB
{
    class Ledstrip
    {
        
        public static async void FadeOne()
        {

            Board.Instance.WriteColor(0, 0, 0);

            while (Setting.Instance.FadeOneOn == true)
            {
                for (ushort x = 0; x < 255; x++)
                {
                    if (Setting.Instance.FadeOneOn == false)
                    {
                        Board.Instance.WriteColor(0, 0, 0);
                        return;
                    }

                    switch (Setting.Instance.fadeOneColor)
                    {
                        case "Red":
                            Board.Instance.WriteColor(x, 0, 0);
                            break;
                        case "Green":
                            Board.Instance.WriteColor(0, x, 0);
                            break;
                        case "Blue":
                            Board.Instance.WriteColor(0, 0, x);
                            break;
                        case "Yellow":
                            Board.Instance.WriteColor(x, 0, x);
                            break;
                        case "Purple":
                            Board.Instance.WriteColor((int)Math.Round(x / 1.99), 0, (int)Math.Round(x / 1.99));
                            break;
                        case "White":
                            Board.Instance.WriteColor(x, x, x);
                            break;
                        case "Cyan":
                          Board.Instance.WriteColor(0, x, x);
                            break;
                        default:
                          Board.Instance.WriteColor(0, 0, 0);
                            break;
                    }

                    await Board.Instance.Delay(Setting.Instance.fadeOneTime);
                }

                for (ushort x = 255; x > 0; x--)
                {
                    if (Setting.Instance.FadeOneOn == false)
                    {
                        Board.Instance.WriteColor(0, 0, 0);
                        return;
                    }

                    switch (Setting.Instance.fadeOneColor)
                    {
                        case "Red":
                          Board.Instance.WriteColor(x, 0, 0);
                            break;
                        case "Green":
                          Board.Instance.WriteColor(0, x, 0);
                            break;
                        case "Blue":
                          Board.Instance.WriteColor(0, 0, x);
                            break;
                        case "Yellow":
                          Board.Instance.WriteColor(x, 0, x);
                            break;
                        case "Purple":
                          Board.Instance.WriteColor((int)Math.Round(x / 1.99), 0, (int)Math.Round(x / 1.99));
                            break;
                        case "White":
                         Board.Instance.WriteColor(x, x, x);
                            break;
                        case "Cyan":
                        Board.Instance.WriteColor(0, x, x);
                            break;
                        default:
                         Board.Instance.WriteColor(0, 0, 0);
                            break;
                    }
                    await Board.Instance.Delay(Setting.Instance.fadeOneTime);

                }

            }


        }
        
        public static async void Fade()
        {
            Board.Instance.WriteColor(0, 0, 0);

            while (Setting.Instance.FadeOn == true)
            {

                Board.instance.WriteColor(0, 0, 0);

                ushort[] rgbColour = { 255, 0, 0 };


                for (int decColour = 0; decColour < 3; decColour += 1)
                {

                    int incColour = decColour == 2 ? 0 : decColour + 1;



                    for (int i = 0; i < 255; i += 1)
                    {
                        
                        if (Setting.Instance.FadeOn == false)
                        {
                            Board.Instance.WriteColor(0,0,0);
                            return;
                        }
                        rgbColour[decColour] -= 1;
                        rgbColour[incColour] += 1;

                        Board.instance.WriteColor(rgbColour[0], rgbColour[1], rgbColour[2]);
                        await Board.instance.Delay(Setting.Instance.fadeTime);
                    }

                }

            }

            Board.instance.WriteColor(0, 0, 0);

        }

        

        public static async void Flash()
        {

            Board.Instance.WriteColor(0, 0, 0);

            while (Setting.Instance.FlashOn == true)
            {

                if (Setting.Instance.FlashOn == false)
                {
                    return;
                }

                switch (Setting.Instance.flashColor)
                {
                    case "Red":
                       Board.Instance.WriteColor(255, 0, 0);
                        break;
                    case "Green":
                       Board.Instance.WriteColor(0, 255, 0);
                        break;
                    case "Blue":
                       Board.Instance.WriteColor(0, 0, 255);
                        break;
                    case "Yellow":
                       Board.Instance.WriteColor(255, 0, 255);
                        break;
                    case "Purple":
                       Board.Instance.WriteColor(128, 0, 128);
                        break;
                    case "White":
                       Board.Instance.WriteColor(255, 255, 255);
                        break;
                    case "Cyan":
                      Board.Instance.WriteColor(0, 255, 255);
                        break;
                    default:
                       Board.Instance.WriteColor(0, 0, 0);
                        break;
                }

                await Board.Instance.Delay(Setting.Instance.flashTime);

               Board.Instance.WriteColor(0, 0, 0);

                await Board.Instance.Delay(Setting.Instance.flashTime);


            }
        }

    
    }
}
