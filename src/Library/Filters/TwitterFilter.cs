using System;
using System.Drawing;
using Ucu.Poo.Twitter;


namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y retorna su negativo.
    /// </remarks>
    public class TwitterFilter : IFilter
    {
        /// Un filtro que retorna el negativo de la imagen recibida.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>La imagen recibida pero en negativo.</returns>
        public IPicture Filter(IPicture image)
        {
            IPicture result = image.Clone();

            var twitter = new TwitterImage();

            PictureProvider provider = new PictureProvider();
            provider.SavePicture(result, "twitterPost.jpg");

            Console.WriteLine(twitter.PublishToTwitter("text", @"twitterPost.jpg"));

            return result;
        }
    }
}
