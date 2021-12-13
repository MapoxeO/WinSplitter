using System;

namespace MapoxeO.Utils.FileSpliters {
    class Program {
        unsafe static void Main(string[] args) {
            var path = "test.bin";
            BinFileSplitter bfs = new BinFileSplitter(path);
            bfs.Split(5, true);
        }
    }
}