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
        /// Get each word with its max ocurrence for each list of messages.
        /// It removes empty values.
        /// </summary>
        /// <param name="messages">List of list of strings.</param>
        /// <returns>A dictionary with each word and its ocurrences.</returns>
        public static IDictionary<string, int> GetWordsCount(IList<IList<string>> messages)
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            foreach (IList<string> satelliteMessages in messages)
            {
                var ocurrencesCount = satelliteMessages
                                    .Where(x => !string.IsNullOrWhiteSpace(x))
                                    .GroupBy(key => key)
                                    .Select(g => new { g.Key, Count = g.Count() });

                foreach (var element in ocurrencesCount)
                {
                    if (wordsCount.TryGetValue(element.Key, out int value))
                    {
                        if (element.Count > value)
                        {
                            wordsCount[element.Key] = element.Count;
                        }
                    }
                    else
                    {
                        wordsCount.Add(element.Key, element.Count);
                    }
                }
            }

            return wordsCount;
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
    }
}
