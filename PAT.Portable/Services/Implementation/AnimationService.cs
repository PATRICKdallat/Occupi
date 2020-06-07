using System.Threading.Tasks;
using Xamarin.Forms;

namespace PAT.Portable.Services
{
    public class AnimationService
    {
        private Task TranslateTask(VisualElement view, double x, double y, uint animationTime, Easing easing = null)
            => view.TranslateTo(x,y, animationTime, easing);

        private Task ScaleTask(VisualElement view, double scale, uint animationTime, Easing easing = null)
            => view.ScaleTo(scale, animationTime, easing);

        private Task RotateTask(VisualElement view, double degree, uint animationTime, Easing easing = null)
            => view.RotateTo(degree, animationTime,easing);

        private Task FadeTask(VisualElement view, double opacity, uint animationTime, Easing easing = null)
            => view.FadeTo(opacity, animationTime, easing);
    }
}
