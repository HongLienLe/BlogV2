using NUnit.Framework;
using BlogV2.Models;

namespace Tests
{
    public class ReadFileTest
    {
        [Test]
        public void return_true_if_it_gets_correct_data_is_assigned_to_Title()
        {
            ReadFile test = new ReadFile();

            var resultedFilePath = test.LoadEntries("/Users/hongle/Projects/BlogV2/BlogV2/Data");

            var TitleFromSpicyCucumberEntry = resultedFilePath[0].Title;

            Assert.AreEqual("Seasoned Spicy Cucumber", TitleFromSpicyCucumberEntry);
        }
        [Test]
        public void return_empty_entry_if_information_isnt_there()
        {
            ReadFile test = new ReadFile();
            var resultContent = test.LoadEntries("");
            Assert.AreEqual(null, resultContent);
        }
    }
}