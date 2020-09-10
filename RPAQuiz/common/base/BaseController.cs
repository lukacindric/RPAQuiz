
namespace RPAQuiz.common
{
        public abstract class BaseController
        {
        public readonly BaseForm view;

        public BaseController(BaseForm view)
        {
            this.view = view;
        }
    }
    }