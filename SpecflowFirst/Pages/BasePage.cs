namespace SpecflowFirst.Pages
{
    public class BasePage
    {
        //implement generics on this page

        public T As<T>() where T : BasePage
        {
            return (T)this;
        }

     

    }
}
