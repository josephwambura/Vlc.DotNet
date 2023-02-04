namespace Vlc.DotNet.Core.Interops
{
    public static class VlcMediaInstanceExtensions
    {
        public static VlcMediaInstance AddOptionToMedia(this VlcMediaInstance mediaInstance, VlcManager manager, string option)
        {
            manager.AddOptionToMedia(mediaInstance, option);
            return mediaInstance;
        }

        public static VlcMediaInstance AddOptionToMedia(this VlcMediaInstance mediaInstance, VlcManager manager, string[] option)
        {
            manager.AddOptionToMedia(mediaInstance, option);
            return mediaInstance;
        }
    }
}
