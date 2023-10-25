using System.Drawing;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y la retorna en escala de grises.
    /// </remarks>
    public class FilterConditional : IFilter
    {
        /// <summary>
        /// Un filtro que retorna la imagen recibida con un filtro de escala de grises aplicado.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>La imagen recibida pero en escala de grises.</returns>
        public IPicture Filter(IPicture image)
        {
            IPicture result = image.Clone();


            CognitiveFace face = new CognitiveFace();
            
            if (face.Recognize(result))
            {
                IPipe pipeNull = new PipeNull();
                result = pipeNull.Send(result);

                IFilter twitterFilter = new FilterTwitter(); //no existe este filtro
                IPipe pipeSerial = new PipeSerial(twitterFilter, pipeNull);
                result = pipeSerial.Send(result);

                IPipe pipeFork = new PipeFork(pipeFork, twitterFilter);
                result = pipeFork.Send(result)
            }
            else
            {
                IPipe pipeNull = new PipeNull();
                result = pipeNull.Send(result);

                IFilter negativeFilter = new FilterNegative();
                IPipe pipeSerial = new PipeSerial(negativeFilter, pipeNull);
                result = pipeSerial.Send(result);

                IPipe pipeFork = new PipeFork(pipeFork, negativeFilter);
                result = pipeFork.Send(result)
            }

            return result;
        }
    }
}
