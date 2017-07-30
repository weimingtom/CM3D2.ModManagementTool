namespace CM3D2.ModManager.Mod
{
    public enum CacheLoadOption
    {
        NO_CACHE, //캐시정보를 읽어들이지 않습니다.
        READ_ONLY_REFERENCE, //레퍼런스 정보만을 사용합니다
        READ_ALL_CHECK_EXIST, //파일 목록 정보도 사용하지만, 파일의 존재여부는 확인합니다.
        READ_ALL //파일 목록 정보를 사용하며, 이 정보를 전적으로 신뢰합니다.
    }
}