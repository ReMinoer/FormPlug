namespace RedButton.WindowsForm.Sample
{
    public class MainPresenter
    {
        private readonly IMainView _view;

        public MainPresenter(IMainView view)
        {
            _view = view;
        }
    }

    public interface IMainView {}
}