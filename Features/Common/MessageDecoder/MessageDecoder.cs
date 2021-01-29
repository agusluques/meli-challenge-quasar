// <copyright file="MessageDecoder.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FuegoDeQuasar.Features.Common.MessageDecoder
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Decoder of the sender message.
    /// </summary>
    public static class MessageDecoder
    {
        /// <summary>
        /// Gets original message length.
        /// </summary>
        /// <param name="messages">List of list of strings.</param>
        /// <returns>Message length.</returns>
        public static int GetMessageLength(IList<IList<string>> messages)
        {
            return messages.Max((message) => WordsBetweenFirstToEnd(message));
        }

        /// <summary>
        /// Normalize lists to be the size as required.
        /// Deleting initial offset.
        /// </summary>
        /// <param name="messages">List of list of strings.</param>
        /// <param name="messageLength">Length of list required.</param>
        public static void NormalizeLists(IList<IList<string>> messages, int messageLength)
        {
            foreach (List<string> satelliteMessages in messages)
            {
                if (satelliteMessages.Count() > messageLength)
                {
                    satelliteMessages.RemoveRange(0, satelliteMessages.Count() - messageLength);
                }
            }
        }

        private static int WordsBetweenFirstToEnd(IList<string> message)
        {
            int indexOfFirstNonEmptyWord = message.Select((message, index) => new { message, index }).FirstOrDefault(m => !string.IsNullOrEmpty(m.message)).index;

            return message.Count - indexOfFirstNonEmptyWord;
        }
    }
}
