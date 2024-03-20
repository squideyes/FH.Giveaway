// ********************************************************
// The use of this source code is licensed under the terms
// of the MIT License (https://opensource.org/licenses/MIT)
// ********************************************************

using System.Collections;

namespace FH.Giveaway;

internal class BookInfoSet : IEnumerable<BookInfo>
{
    private readonly List<BookInfo> bookInfos = [];

    public BookInfoSet(IConfiguration config)
    {
        var books = new Dictionary<string, int>();

        config.GetSection("Books").Bind(books);

        var infos = GetBookInfos().ToDictionary(v => v.Code);

        foreach (var code in books.Keys)
        {
            var bookInfo = infos[code];

            bookInfo.Quantity = books[code];

            if (bookInfo.Quantity >= 1)
                bookInfos!.Add(bookInfo);
        }
    }

    private static List<BookInfo> GetBookInfos()
    {
        return
        [
            new()
            {
                Code = "HumanCompatible",
                ASIN = "B07N5J5FTS",
                Title = "Human Compatible: Artificial Intelligence and the Problem of Control",
                Author = "Stuart Russel",
                PubDate = new DateTime(2019, 10, 19),
                ImageFile = "HumanCompatible.jpg",
                Slug = "Human-Compatible-Artificial-Intelligence-Problem"
            },
            new()
            {
                Code = "Superintelligence",
                ASIN = "B00LOOCGB2",
                Title = "Superintelligence: Paths, Dangers, Strategies",
                Author = "Nick Bostrom",
                PubDate = new DateTime(2014, 7, 2),
                ImageFile = "Superintelligence.png",
                Slug = "Superintelligence-Dangers-Strategies-Nick-Bostrom"
            },
            new()
            {
                Code = "TheAlignmentProblem",
                ASIN = "B085T55LGKn",
                Title = "The Alignment Problem: Machine Learning and Human Values",
                Author = "Brian Christian",
                PubDate = new DateTime(2020, 10, 6),
                ImageFile = "TheAlignmentProblem.jpg",
                Slug = "Alignment-Problem-Machine-Learning-Values"
            },
            new()
            {
                Code = "ThePrecipice",
                ASIN = "B07V9GHKYP",
                Title = "The Precipice: Existential Risk and the Future of Humanity",
                Author = "Toby Ord",
                PubDate = new DateTime(2020, 3, 24),
                ImageFile = "ThePrecipise.jpg",
                Slug = "Precipice-Existential-Risk-Future-Humanity"
            },
            new()
            {
                Code = "Uncontrollable",
                ASIN = "B0CNYMF89Z",
                Title = "Uncontrollable : The Threat of Artificial Superintelligence and the Race to Save the World",
                Author = "Darren McGee",
                PubDate = new DateTime(2020, 3, 24),
                ImageFile = "Uncontrollable.png",
                Slug = "Uncontrollable-Threat-Artificial-Superintelligence-World"
            }
        ];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<BookInfo> GetEnumerator() => bookInfos.GetEnumerator();
}