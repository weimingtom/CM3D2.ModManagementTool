using System.Collections.Generic;
using System.IO;

namespace CM3D2.ModManager.Mod.File
{
    public class ReferenceFile : BaseFile
    {
        //이 파일이 가지고 있는 외부파일(이 파일이 사용하는 파일의) 레퍼런스, Verify 이후 생성됩니다.
        public List<string> references = new List<string>();
        protected bool referenceLoaded = false;

        private CacheStore store;

        public ReferenceFile(string root, string path) : base(root, path)
        {
            this.store = ModContainer.Single.CacheStore;
            var query = store.QueryReferences(path);
            if (query != null)
            {
                references = query;
                referenceLoaded = true;
            }
        }

        public void OnReferenceLoad()
        {
            referenceLoaded = true;
            store.RegisterReference(this);
        }
    }
}