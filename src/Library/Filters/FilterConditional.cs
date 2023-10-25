using System.Drawing;
using Ucu.Poo.Cognitive;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y la retorna en escala de grises.
    /// </remarks>
    public class FilterConditional : IConditionalFilter
    {
        /// <summary>
        /// Un filtro que retorna la imagen recibida con un filtro de escala de grises aplicado.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>La imagen recibida pero en escala de grises.</returns>
        public bool Filter(IPicture image)
        {
            IPicture result = image.Clone();

            PictureProvider provider = new PictureProvider();
            provider.SavePicture(result, "pictureConditional.jpg");

            CognitiveFace picture = new CognitiveFace();
            picture.Recognize("pictureConditional.jpg");

            bool conditional = picture.FaceFound;

            return conditional;

/*
            if (conditional)
            {
                IPipe pipeNull = new PipeNull();
                result = pipeNull.Send(result);

                IFilter twitterFilter = new FilterTwitter(); 
                IPipe pipeSerial = new PipeSerial(twitterFilter, pipeNull);
                result = pipeSerial.Send(result);

                IPipe pipeFork = new PipeFork(pipeFork, twitterFilter);
                result = pipeFork.Send(result);
            }
            else
            {
                IPipe pipeNull = new PipeNull();
                result = pipeNull.Send(result);

                IFilter negativeFilter = new FilterNegative();
                IPipe pipeSerial = new PipeSerial(negativeFilter, pipeNull);
                result = pipeSerial.Send(result);

                IPipe pipeFork = new PipeFork(pipeFork, negativeFilter);
                result = pipeFork.Send(result);
            }
*/
        }
    }
}
