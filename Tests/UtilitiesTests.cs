using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Tests {
    [TestClass]
    public class UtilitiesTests {
        private int RandomInt() =>
            Guid.NewGuid().GetHashCode();


        [TestMethod]
        public void Replicate_FromSingleton() {
            int toReplicate = RandomInt();
            int[] expected = new[] {
                toReplicate,
                toReplicate,
                toReplicate,
                toReplicate,
                toReplicate,
                toReplicate,
                toReplicate,
                toReplicate,
                toReplicate,
                toReplicate,
                toReplicate,
                toReplicate,
                toReplicate,
                toReplicate,
                toReplicate,
                toReplicate
            };
            int[] actual = 
                toReplicate
                .Replicate((uint)expected.Length)
                .ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Pipe_Func() {
            static int addFive(int to) => to + 5;
            int toPipe = RandomInt();
            int expected = addFive(toPipe);
            int actual = toPipe.Pipe(addFive);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Pipe_Action() {
            int expected = 0;
            int saveValueWithoutPipe(int val) => expected = val;
            int actual = 0;
            int saveValueWithPipe(int val) => actual = val;
            int toPipe = RandomInt() ;
            saveValueWithoutPipe(toPipe);
            toPipe.Pipe(saveValueWithPipe);
            Assert.AreEqual(expected, actual);
        }
    }
}