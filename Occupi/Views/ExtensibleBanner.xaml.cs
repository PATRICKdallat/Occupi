using Xamarin.Forms;

namespace Occupi.Views
{
    public partial class ExtensibleBanner : ContentView
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
              propertyName: nameof(Text),
              returnType: typeof(string),
              declaringType: typeof(ExtensibleBanner),
              propertyChanged: OnTextPropertyChanged);

        public static readonly BindableProperty IconSourceProperty = BindableProperty.Create(
             propertyName: nameof(IconSource),
             returnType: typeof(string),
             declaringType: typeof(ExtensibleBanner),
             propertyChanged: OnIconSourcePropertyChanged);

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public string IconSource
        {
            get => (string)GetValue(IconSourceProperty);
            set => SetValue(IconSourceProperty, value);
        }

        public ExtensibleBanner()
        {
            InitializeComponent();

            BannerText.Text = Text;
            BannerIcon.Source = IconSource;
        }

        public ExtensibleBanner(string bannerText, string bannerIconSource)
        {
            InitializeComponent();

            BannerText.Text = bannerText;
            BannerIcon.Source = bannerIconSource;
        }

        private static void OnTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((ExtensibleBanner)bindable).BannerText.Text = newValue as string;
        }

        private static void OnIconSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((ExtensibleBanner)bindable).BannerIcon.Source = newValue as string;
        }
    }
}
