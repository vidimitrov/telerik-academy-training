namespace DocumentSystemEngine.DocumentNamespace
{
    using System;
    using System.Collections.Generic;

    public class VideoDocument : MultimediaDocument
    {
        public long? FrameRate { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "framerate":
                    this.FrameRate = long.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);

            KeyValuePair<string, object> frameRateProperty = new KeyValuePair<string, object>("framerate", this.FrameRate);
            output.Add(frameRateProperty);
        }
    }
}