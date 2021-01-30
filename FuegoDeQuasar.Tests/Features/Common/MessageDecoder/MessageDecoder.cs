using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FuegoDeQuasar.Tests.Features.Common.MessageDecoder
{
    public class MessageDecoder
    {
        /// <summary>
        /// Message: I am agus agus
        /// 1: "I", "", "agus", ""
        /// 2: "", "", "", "am", "", ""
        /// 3: "I", "", "", "agus"
        /// </summary>
        [Fact]
        public void GetLength_InputIsDocumented_Return4()
        {
            IList<IList<string>> messages = new List<IList<string>>();

            messages.Add(new List<string> { "I", "", "agus", "" });
            messages.Add(new List<string> { "", "", "", "am", "", "" });
            messages.Add(new List<string> { "I", "", "", "agus" });

            int result = FuegoDeQuasar.Features.Common.MessageDecoder.MessageDecoder.GetMessageLength(messages);

            Assert.Equal(4, result);
        }

        /// <summary>
        /// Message: I am agus agus
        /// 1: "I", "", "agus", ""
        /// 2: "", "", "", "am", "", ""
        /// 3: "I", "", "", "agus"
        /// </summary>
        [Fact]
        public void NormalizeLists_InputIsDocumented_Change3ListsLength4()
        {
            IList<IList<string>> messages = new List<IList<string>>();


            var listWithGap = new List<string> { "", "", "", "am", "", "" };

            messages.Add(new List<string> { "I", "", "agus", "" });
            messages.Add(listWithGap);
            messages.Add(new List<string> { "I", "", "", "agus" });

            FuegoDeQuasar.Features.Common.MessageDecoder.MessageDecoder.NormalizeLists(messages, 4);

            Assert.Equal(4, listWithGap.Count);
            Assert.Equal("", listWithGap[0]);
            Assert.Equal("am", listWithGap[1]);
            Assert.Equal("", listWithGap[2]);
            Assert.Equal("", listWithGap[3]);
        }
    }
}
