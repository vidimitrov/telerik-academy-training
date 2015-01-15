namespace DocumentSystemEngine.DocumentNamespace
{
    using System;
    using System.Collections.Generic;

    public class AudioDocument : MultimediaDocument
    {
        public long? SampleRate { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            switch (key)
            {
                case "samplerate":
                    this.SampleRate = long.Parse(value);
                    break;
                default:
                    base.LoadProperty(key, value);
                    break;
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);

            KeyValuePair<string, object> sampleRateProperty = new KeyValuePair<string, object>("samplerate", this.SampleRate);
            output.Add(sampleRateProperty);
        }
    }
}