using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using Ucu.Poo.Twitter;

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

        //ejercicio 3
        /*
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");

            IPipe pipeNull = new PipeNull();
            //picture = pipeNull.Send(picture);

            IFilter filter1 = new FilterNegative();
            IPipe pipeSerial = new PipeSerial(filter1, pipeNull);
            //picture = pipeSerial.Send(picture);

            //publicación en twitter
            IFilter filterTwit = new TwitterFilter();
            IPipe pipeSerialTwit = new PipeSerial(filterTwit, pipeSerial);

            IFilter filter2 = new FilterGreyscale();
            IPipe pipeSerial2 = new PipeSerial(filter2, pipeSerialTwit);
            //picture = pipeSerial.Send(picture);

            picture = pipeSerial2.Send(picture);

            PictureProvider provider2 = new PictureProvider();
            provider2.SavePicture(picture, "lukeModified.jpg");
        }
        */

        //ejercicio 4
        static void Main(string[] args)
        {
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");    

            IPipe pipeNull = new PipeNull();

            IFilter filterNegative = new FilterNegative();
            IPipe pipeSerialFalse = new PipeSerial(filterNegative, pipeNull);

            IFilter filterTwit = new TwitterFilter();
            IPipe pipeSerialTrue = new PipeSerial(filterTwit, pipeNull);

            IConditionalFilter conditionalFilter = new FilterConditional();
            IPipe pipeConditional = new PipeConditional(conditionalFilter, pipeSerialTrue, pipeSerialFalse);

            IFilter greyFilter = new FilterGreyscale();
            IPipe pipeGrey = new PipeSerial(greyFilter, pipeConditional);

            picture = pipeGrey.Send(picture);

            PictureProvider provider2 = new PictureProvider();
            provider2.SavePicture(picture, "lukeModified.jpg");
        }
    }
}
