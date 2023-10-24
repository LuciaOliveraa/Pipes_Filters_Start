using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {

        //ejercicio 1
        /*
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");

            IPipe pipeNull = new PipeNull();
            picture = pipeNull.Send(picture);

            IFilter filter1 = new FilterNegative();
            IPipe pipeSerial = new PipeSerial(filter1, pipeNull);
            picture = pipeSerial.Send(picture);

            IFilter filter2 = new FilterGreyscale();
            IPipe pipeSerial2 = new PipeSerial(filter2, pipeSerial);
            picture = pipeSerial.Send(picture);

            PictureProvider provider = new PictureProvider();
            provider.SavePicture(picture, @"luke.jpg");
        }
        */

        //ejercicio 2
        /*
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");

            IPipe pipeNull = new PipeNull();
            picture = pipeNull.Send(picture);

            IFilter filter1 = new FilterNegative();
            IPipe pipeSerial = new PipeSerial(filter1, pipeNull);
            picture = pipeSerial.Send(picture);

            IFilter filter2 = new FilterGreyscale();
            IPipe pipeSerial2 = new PipeSerial(filter2, pipeSerial);
            picture = pipeSerial.Send(picture);

            picture = pipeSerial2.Send(picture);

            PictureProvider provider2 = new PictureProvider();
            provider2.SavePicture(picture, "lukeModified.jpg");
        }
        */

        



    }
}
