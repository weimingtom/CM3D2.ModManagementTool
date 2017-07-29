using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

public class Debug
{
    public static void Log(string s) { Console.WriteLine(s); }
    public static void LogWarning(string s) { Console.WriteLine(s); }
    public static void LogError(string s) { Console.WriteLine(s); }
}

public class MonoBehaviour
{

}

/**
    Source Code for Access CM3D2 arc Files
    
    Copied from CM3D2's DLL(Decompiled by dnSpy)
*/
namespace Injected
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    using System;

    using System;
    using System.Text;

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    using System;

    // Token: 0x02000335 RID: 821
    public enum MPN
    {
        // Token: 0x040013CD RID: 5069
        null_mpn,
        // Token: 0x040013CE RID: 5070
        MuneL,
        // Token: 0x040013CF RID: 5071
        MuneTare,
        // Token: 0x040013D0 RID: 5072
        RegFat,
        // Token: 0x040013D1 RID: 5073
        ArmL,
        // Token: 0x040013D2 RID: 5074
        Hara,
        // Token: 0x040013D3 RID: 5075
        RegMeet,
        // Token: 0x040013D4 RID: 5076
        KubiScl,
        // Token: 0x040013D5 RID: 5077
        UdeScl,
        // Token: 0x040013D6 RID: 5078
        EyeScl,
        // Token: 0x040013D7 RID: 5079
        EyeSclX,
        // Token: 0x040013D8 RID: 5080
        EyeSclY,
        // Token: 0x040013D9 RID: 5081
        EyePosX,
        // Token: 0x040013DA RID: 5082
        EyePosY,
        // Token: 0x040013DB RID: 5083
        HeadX,
        // Token: 0x040013DC RID: 5084
        HeadY,
        // Token: 0x040013DD RID: 5085
        DouPer,
        // Token: 0x040013DE RID: 5086
        sintyou,
        // Token: 0x040013DF RID: 5087
        koshi,
        // Token: 0x040013E0 RID: 5088
        kata,
        // Token: 0x040013E1 RID: 5089
        west,
        // Token: 0x040013E2 RID: 5090
        MuneUpDown,
        // Token: 0x040013E3 RID: 5091
        MuneYori,
        // Token: 0x040013E4 RID: 5092
        body,
        // Token: 0x040013E5 RID: 5093
        moza,
        // Token: 0x040013E6 RID: 5094
        head,
        // Token: 0x040013E7 RID: 5095
        hairf,
        // Token: 0x040013E8 RID: 5096
        hairr,
        // Token: 0x040013E9 RID: 5097
        hairt,
        // Token: 0x040013EA RID: 5098
        hairs,
        // Token: 0x040013EB RID: 5099
        haircolor,
        // Token: 0x040013EC RID: 5100
        skin,
        // Token: 0x040013ED RID: 5101
        acctatoo,
        // Token: 0x040013EE RID: 5102
        underhair,
        // Token: 0x040013EF RID: 5103
        hokuro,
        // Token: 0x040013F0 RID: 5104
        mayu,
        // Token: 0x040013F1 RID: 5105
        lip,
        // Token: 0x040013F2 RID: 5106
        eye,
        // Token: 0x040013F3 RID: 5107
        eye_hi,
        // Token: 0x040013F4 RID: 5108
        chikubi,
        // Token: 0x040013F5 RID: 5109
        chikubicolor,
        // Token: 0x040013F6 RID: 5110
        wear,
        // Token: 0x040013F7 RID: 5111
        skirt,
        // Token: 0x040013F8 RID: 5112
        mizugi,
        // Token: 0x040013F9 RID: 5113
        bra,
        // Token: 0x040013FA RID: 5114
        panz,
        // Token: 0x040013FB RID: 5115
        stkg,
        // Token: 0x040013FC RID: 5116
        shoes,
        // Token: 0x040013FD RID: 5117
        headset,
        // Token: 0x040013FE RID: 5118
        glove,
        // Token: 0x040013FF RID: 5119
        acchead,
        // Token: 0x04001400 RID: 5120
        hairaho,
        // Token: 0x04001401 RID: 5121
        accha,
        // Token: 0x04001402 RID: 5122
        acchana,
        // Token: 0x04001403 RID: 5123
        acckamisub,
        // Token: 0x04001404 RID: 5124
        acckami,
        // Token: 0x04001405 RID: 5125
        accmimi,
        // Token: 0x04001406 RID: 5126
        accnip,
        // Token: 0x04001407 RID: 5127
        acckubi,
        // Token: 0x04001408 RID: 5128
        acckubiwa,
        // Token: 0x04001409 RID: 5129
        accheso,
        // Token: 0x0400140A RID: 5130
        accude,
        // Token: 0x0400140B RID: 5131
        accashi,
        // Token: 0x0400140C RID: 5132
        accsenaka,
        // Token: 0x0400140D RID: 5133
        accshippo,
        // Token: 0x0400140E RID: 5134
        accanl,
        // Token: 0x0400140F RID: 5135
        accvag,
        // Token: 0x04001410 RID: 5136
        megane,
        // Token: 0x04001411 RID: 5137
        accxxx,
        // Token: 0x04001412 RID: 5138
        handitem,
        // Token: 0x04001413 RID: 5139
        acchat,
        // Token: 0x04001414 RID: 5140
        onepiece,
        // Token: 0x04001415 RID: 5141
        set_maidwear,
        // Token: 0x04001416 RID: 5142
        set_mywear,
        // Token: 0x04001417 RID: 5143
        set_underwear,
        // Token: 0x04001418 RID: 5144
        folder_eye,
        // Token: 0x04001419 RID: 5145
        folder_mayu,
        // Token: 0x0400141A RID: 5146
        folder_underhair,
        // Token: 0x0400141B RID: 5147
        folder_skin,
        // Token: 0x0400141C RID: 5148
        kousoku_upper,
        // Token: 0x0400141D RID: 5149
        kousoku_lower,
        // Token: 0x0400141E RID: 5150
        seieki_naka,
        // Token: 0x0400141F RID: 5151
        seieki_hara,
        // Token: 0x04001420 RID: 5152
        seieki_face,
        // Token: 0x04001421 RID: 5153
        seieki_mune,
        // Token: 0x04001422 RID: 5154
        seieki_hip,
        // Token: 0x04001423 RID: 5155
        seieki_ude,
        // Token: 0x04001424 RID: 5156
        seieki_ashi
    }


    // Token: 0x0200079E RID: 1950
    public class UTY : MonoBehaviour
    {
        // Token: 0x06003589 RID: 13705 RVA: 0x00189358 File Offset: 0x00187558
        public static string[] GetStringList(string sss)
        {
            List<string> list = new List<string>();
            if (sss == null)
            {
                sss = string.Empty;
            }
            int length = sss.Length;
            int i = 0;
            string text = string.Empty;
            while (i < length)
            {
                while (i < length && (sss[i] == ' ' || sss[i] == '\t' || sss[i] == '\u3000' || sss[i] == '\r'))
                {
                    i++;
                }
                if (i == length)
                {
                    break;
                }
                if (i < length && sss[i] == '"')
                {
                    i++;
                    while (i < length && sss[i] != '"')
                    {
                        text += sss[i];
                        i++;
                    }
                    i++;
                }
                else
                {
                    while (i < length && sss[i] != ' ' && sss[i] != '\t' && sss[i] != '\u3000' && sss[i] != '\r')
                    {
                        text += sss[i];
                        i++;
                    }
                }
                list.Add(text);
                text = string.Empty;
            }
            return list.ToArray();
        }

        // Token: 0x0600358C RID: 13708 RVA: 0x00189568 File Offset: 0x00187768
        public static string GetStringCom(string sss)
        {
            int length = sss.Length;
            int num = 0;
            string text = string.Empty;
            while (num < length && (sss[num] == ' ' || sss[num] == '\t' || sss[num] == '\u3000'))
            {
                num++;
            }
            if (num < length && sss[num] == '/')
            {
                return string.Empty;
            }
            if (num < length && sss[num] == '"')
            {
                num++;
                while (num < length && sss[num] != '"')
                {
                    text += sss[num];
                    num++;
                }
                num++;
            }
            else
            {
                while (num < length && sss[num] != ' ' && sss[num] != '\t' && sss[num] != '\u3000')
                {
                    text += sss[num];
                    num++;
                }
            }
            return text.ToLower();
        }

        // Token: 0x0600358D RID: 13709 RVA: 0x00189688 File Offset: 0x00187888
        public static string[] GetStringListSS(string sss)
        {
            List<string> list = new List<string>();
            int length = sss.Length;
            int i = 0;
            string text = string.Empty;
            while (i < length)
            {
                while (i < length && (sss[i] == ' ' || sss[i] == '\t' || sss[i] == '\u3000'))
                {
                    i++;
                }
                if (i == length)
                {
                    break;
                }
                if (i < length && sss[i] == '"')
                {
                    i++;
                    while (i < length && sss[i] != '"')
                    {
                        text += sss[i];
                        i++;
                    }
                    i++;
                }
                else if (i < length && sss[i] == '『')
                {
                    i++;
                    while (i < length && sss[i] != '』')
                    {
                        text += sss[i];
                        i++;
                    }
                    i++;
                }
                else
                {
                    while (i < length && sss[i] != ' ' && sss[i] != '\t' && sss[i] != '\u3000')
                    {
                        text += sss[i];
                        i++;
                    }
                }
                list.Add(text);
                text = string.Empty;
            }
            return list.ToArray();
        }

        // Token: 0x0600358E RID: 13710 RVA: 0x00189810 File Offset: 0x00187A10
        public static string[] GetStringListSS_2(string sss)
        {
            List<string> list = new List<string>();
            int length = sss.Length;
            int i = 0;
            string text = string.Empty;
            while (i < length)
            {
                while (i < length && (sss[i] == ' ' || sss[i] == '\t' || sss[i] == '\u3000'))
                {
                    i++;
                }
                if (i == length)
                {
                    break;
                }
                if (i < length && sss[i] == '"')
                {
                    i++;
                    text += "\"";
                    while (i < length && sss[i] != '"')
                    {
                        text += sss[i];
                        i++;
                    }
                    i++;
                    text += "\"";
                }
                else if (i < length && sss[i] == '『')
                {
                    i++;
                    text += "『";
                    while (i < length && sss[i] != '』')
                    {
                        text += sss[i];
                        i++;
                    }
                    i++;
                    text += "』";
                }
                else
                {
                    while (i < length && sss[i] != ' ' && sss[i] != '\t' && sss[i] != '\u3000')
                    {
                        text += sss[i];
                        i++;
                    }
                }
                list.Add(text);
                text = string.Empty;
            }
            return list.ToArray();
        }

        // Token: 0x0600358F RID: 13711 RVA: 0x0002308D File Offset: 0x0002128D
        public static int Clamp(int val, int min, int max)
        {
            if (val > max)
            {
                return max;
            }
            if (val < min)
            {
                return min;
            }
            return val;
        }
    }


    public static class Utils
    {
        public static string Unescape(this string txt)
        {
            bool flag = string.IsNullOrEmpty(txt);
            string result;
            if (flag)
            {
                result = txt;
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder(txt.Length);
                int i = 0;
                while (i < txt.Length)
                {
                    int num = txt.IndexOf('\\', i);
                    bool flag2 = num < 0 || num == txt.Length - 1;
                    if (flag2)
                    {
                        num = txt.Length;
                    }
                    stringBuilder.Append(txt, i, num - i);
                    bool flag3 = num >= txt.Length;
                    if (flag3)
                    {
                        break;
                    }
                    char c = txt[num + 1];
                    if (c <= '\\')
                    {
                        if (c <= '\'')
                        {
                            if (c != '"')
                            {
                                if (c != '\'')
                                {
                                    goto IL_17C;
                                }
                                stringBuilder.Append("'");
                            }
                            else
                            {
                                stringBuilder.Append('"');
                            }
                        }
                        else if (c != '0')
                        {
                            if (c != '\\')
                            {
                                goto IL_17C;
                            }
                            stringBuilder.Append('\\');
                        }
                        else
                        {
                            stringBuilder.Append('\0');
                        }
                    }
                    else if (c <= 'b')
                    {
                        if (c != 'a')
                        {
                            if (c != 'b')
                            {
                                goto IL_17C;
                            }
                            stringBuilder.Append('\b');
                        }
                        else
                        {
                            stringBuilder.Append('\a');
                        }
                    }
                    else if (c != 'f')
                    {
                        if (c != 'n')
                        {
                            switch (c)
                            {
                                case 'r':
                                    stringBuilder.Append('\r');
                                    break;
                                case 's':
                                case 'u':
                                    goto IL_17C;
                                case 't':
                                    stringBuilder.Append('\t');
                                    break;
                                case 'v':
                                    stringBuilder.Append('\v');
                                    break;
                                default:
                                    goto IL_17C;
                            }
                        }
                        else
                        {
                            stringBuilder.Append('\n');
                        }
                    }
                    else
                    {
                        stringBuilder.Append('\f');
                    }
                IL_196:
                    i = num + 2;
                    continue;
                IL_17C:
                    stringBuilder.Append('\\').Append(txt[num + 1]);
                    goto IL_196;
                }
                result = stringBuilder.ToString();
            }
            return result;
        }
    }

    // Token: 0x02000152 RID: 338
    public class FileSystemWindows : AFileSystemBase
    {
        // Token: 0x060008CE RID: 2254 RVA: 0x000546E0 File Offset: 0x000528E0
        public FileSystemWindows()
        {
            this.dll_ = DLLManager.cm3d2dll;
            if (this.dll_ == null)
            {
                throw new ArgumentNullException();
            }
            this.file_system_ = this.dll_.call.file_system;
            this.file_system_.CreatemWindowsSystem(ref this.data_);
        }

        // Token: 0x060008CF RID: 2255 RVA: 0x0005474C File Offset: 0x0005294C
        public override bool IsValid()
        {
            return this.file_system_.IsValid(ref this.data_);
        }

        // Token: 0x060008D0 RID: 2256 RVA: 0x00054764 File Offset: 0x00052964
        public override void AddAutoPathForAllFolder()
        {
            this.file_system_.AddAutoPathForAllFolder(ref this.data_);
        }

        // Token: 0x060008D1 RID: 2257 RVA: 0x0005477C File Offset: 0x0005297C
        public unsafe override string[] GetList(string f_str_path, AFileSystemBase.ListType type)
        {
            DLLFileSystem.ListData listData = default(DLLFileSystem.ListData);
            this.file_system_.CreateList(ref this.data_, f_str_path, type, ref listData);
            string[] array = new string[listData.size];
            byte[] empty = new byte[0];
            fixed (byte* value = (this.dll_.tmp_buff != null && this.dll_.tmp_buff.Length != 0) ? dll_.tmp_buff : null)
		    {
                for (int i = 0; i < listData.size; i++)
                {
                    int count = this.file_system_.AtList(ref listData, i, (IntPtr)((void*)value), this.dll_.tmp_buff.Length);
                    array[i] = Encoding.UTF8.GetString(this.dll_.tmp_buff, 0, count);
                }
            }
            this.file_system_.DeleteList(ref listData);
            return array;
        }

        // Token: 0x060008D2 RID: 2258 RVA: 0x00054864 File Offset: 0x00052A64
        public bool AddFolder(string path)
        {
            return this.file_system_.AddFolder(ref this.data_, path);
        }

        // Token: 0x060008D3 RID: 2259 RVA: 0x00054880 File Offset: 0x00052A80
        public bool AddAutoPath(string path)
        {
            return this.file_system_.AddAutoPath(ref this.data_, path);
        }

        // Token: 0x060008D4 RID: 2260 RVA: 0x0005489C File Offset: 0x00052A9C
        public bool SetBaseDirectory(string f_strPathFileName)
        {
            return this.file_system_.SetBaseDirectory(ref this.data_, f_strPathFileName);
        }

        // Token: 0x060008D5 RID: 2261 RVA: 0x000548B8 File Offset: 0x00052AB8
        public override AFileBase FileOpen(string file_name)
        {
            DLLFile.Data file_data = default(DLLFile.Data);
            this.file_system_.GetFile(ref this.data_, file_name, ref file_data);
            if (file_data.object_pointer == IntPtr.Zero)
            {
                return new FileWfNull();
            }
            return new WfFile(file_data);
        }

        // Token: 0x060008D6 RID: 2262 RVA: 0x0005490C File Offset: 0x00052B0C
        public override bool IsExistentFile(string file_name)
        {
            return this.file_system_.IsExistentFile(ref this.data_, file_name);
        }

        // Token: 0x060008D7 RID: 2263 RVA: 0x00054928 File Offset: 0x00052B28
        protected override void Dispose(bool is_release_managed_code)
        {
            if (this.is_disposed_)
            {
                return;
            }
            this.file_system_.DeleteFileSystem(ref this.data_);
            this.dll_ = null;
            this.file_system_ = null;
            this.is_disposed_ = true;
        }

        // Token: 0x170000E0 RID: 224
        // (get) Token: 0x060008D8 RID: 2264 RVA: 0x00054964 File Offset: 0x00052B64
        public override DLLFileSystem.Data object_data
        {
            get
            {
                return this.data_;
            }
        }

        // Token: 0x040008CF RID: 2255
        private Cm3D2Dll dll_;

        // Token: 0x040008D0 RID: 2256
        private DLLFileSystem file_system_;

        // Token: 0x040008D1 RID: 2257
        private DLLFileSystem.Data data_ = default(DLLFileSystem.Data);
    }


    // Token: 0x02000151 RID: 337
    public class WfFile : AFileBase
    {
        // Token: 0x060008C5 RID: 2245 RVA: 0x00054490 File Offset: 0x00052690
        public WfFile(DLLFile.Data file_data)
        {
            this.dll_ = DLLManager.cm3d2dll;
            if (this.dll_ == null)
            {
                throw new ArgumentNullException();
            }
            this.data_ = file_data;
        }

        // Token: 0x060008C6 RID: 2246 RVA: 0x000544BC File Offset: 0x000526BC
        public override bool IsValid()
        {
            return this.dll_.call.file.IsValid(ref this.data_);
        }

        // Token: 0x060008C7 RID: 2247 RVA: 0x000544EC File Offset: 0x000526EC
        public unsafe override int Read(ref byte[] f_byBuf, int f_unReadSize)
        {
            if (!this.IsValid())
            {
                f_byBuf = null;
                return 0;
            }
            if (f_byBuf == null || f_byBuf.Length < f_unReadSize)
            {
                f_byBuf = new byte[f_unReadSize];
            }
            long num;
            byte[] empty = new byte[0];
            fixed (byte* value = (f_byBuf != null && f_byBuf.Length != 0) ? f_byBuf : empty)
		    {
                num = this.dll_.call.file.Read(ref this.data_, (IntPtr)((void*)value), (long)f_unReadSize);
            }
            return (int)num;
        }

        // Token: 0x060008C8 RID: 2248 RVA: 0x00054574 File Offset: 0x00052774
        public unsafe override byte[] ReadAll()
        {
            if (!this.IsValid())
            {
                return null;
            }
            int f_unPos = this.Tell();
            byte[] array = new byte[this.GetSize()];
            byte[] empty = new byte[0];
            fixed (byte* value = (array != null && array.Length != 0) ? array : empty)
            {
                this.dll_.call.file.Read(ref this.data_, (IntPtr)((void*)value), (long)this.GetSize());
            }
            this.Seek(f_unPos, true);
            return array;
        }

        // Token: 0x060008C9 RID: 2249 RVA: 0x000545FC File Offset: 0x000527FC
        public override int Seek(int f_unPos, bool absolute_move)
        {
            this.dll_.call.file.SetSeek(ref this.data_, (long)f_unPos, absolute_move);
            return this.Tell();
        }

        // Token: 0x060008CA RID: 2250 RVA: 0x00054634 File Offset: 0x00052834
        public override int Tell()
        {
            return (int)this.dll_.call.file.GetTell(ref this.data_);
        }

        // Token: 0x060008CB RID: 2251 RVA: 0x00054658 File Offset: 0x00052858
        public override int GetSize()
        {
            return (int)this.dll_.call.file.GetSize(ref this.data_);
        }

        // Token: 0x170000DF RID: 223
        // (get) Token: 0x060008CC RID: 2252 RVA: 0x0005467C File Offset: 0x0005287C
        public override DLLFile.Data object_data
        {
            get
            {
                return this.data_;
            }
        }

        // Token: 0x060008CD RID: 2253 RVA: 0x00054684 File Offset: 0x00052884
        protected override void Dispose(bool is_release_managed_code)
        {
            if (this.is_disposed_)
            {
                return;
            }
            this.dll_.call.file.Close(ref this.data_);
            this.dll_ = null;
            this.data_.object_pointer = (IntPtr)null;
            this.is_disposed_ = true;
        }

        // Token: 0x040008CD RID: 2253
        private DLLFile.Data data_;

        // Token: 0x040008CE RID: 2254
        private Cm3D2Dll dll_;
    }


    public class FileWfNull : AFileBase
    {
        private DLLFile.Data data_ = new DLLFile.Data();

        public override DLLFile.Data object_data
        {
            get
            {
                return this.data_;
            }
        }

        public FileWfNull()
        {
            this.data_.object_pointer = IntPtr.Zero;
        }

        public override bool IsValid()
        {
            return false;
        }

        public override int Read(ref byte[] f_byBuf, int f_unReadSize)
        {
            return 0;
        }

        public override byte[] ReadAll()
        {
            return (byte[])null;
        }

        public override int Seek(int f_unPos, bool absolute_move)
        {
            return 0;
        }

        public override int Tell()
        {
            return 0;
        }

        public override int GetSize()
        {
            return 0;
        }

        protected override void Dispose(bool is_release_managed_code)
        {
        }
    }

    public abstract class AFileBase : IDisposable
    {
        protected bool is_disposed_;

        public abstract DLLFile.Data object_data { get; }

        ~AFileBase()
        {
            this.Dispose(false);
        }

        public abstract bool IsValid();

        public abstract int Seek(int f_unPos, bool absolute_move);

        public abstract int Read(ref byte[] f_byBuf, int f_nReadSize);

        public abstract byte[] ReadAll();

        public abstract int Tell();

        public abstract int GetSize();

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        protected abstract void Dispose(bool is_release_managed_code);
    }

    public class PluginData : IDisposable
    {
        private Dictionary<PluginData.Type, bool> enabled_result_cache_dic_ = new Dictionary<PluginData.Type, bool>();
        protected bool is_disposed_;
        private DLLPluginData dll_plugin_data_;
        private IntPtr class_ptr_;

        public PluginData(AFileSystemBase file_system)
        {
            this.dll_plugin_data_ = DLLManager.cm3d2dll.call.plugin_data;
            this.class_ptr_ = this.dll_plugin_data_.CreatePluginData(file_system.object_data.object_pointer);
        }

        ~PluginData()
        {
            this.Dispose(false);
        }

        public bool IsEnabled(PluginData.Type type)
        {
            if (type == PluginData.Type.NON)
                return true;
            if (!this.enabled_result_cache_dic_.ContainsKey(type))
                this.enabled_result_cache_dic_.Add(type, this.dll_plugin_data_.IsEnabled(this.class_ptr_, (int)type));
            return this.enabled_result_cache_dic_[type];
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        protected unsafe void Dispose(bool is_release_managed_code)
        {
            if (this.is_disposed_)
                return;
            this.enabled_result_cache_dic_.Clear();
            if (this.class_ptr_ == IntPtr.Zero)
                this.dll_plugin_data_.DeletePluginData(this.class_ptr_);
            this.class_ptr_ = (IntPtr)((void*)null);
            this.dll_plugin_data_ = (DLLPluginData)null;
            this.is_disposed_ = true;
        }

        public enum Type
        {
            NON = -1,
            VP001 = 0,
            PERSONAL001 = 1,
            PP001 = 2,
            DENKIGAI2015W_VOICE_CD = 3,
            DENKIGAI2015W = 4,
            EVENT001 = 5,
            PERSONAL002 = 6,
            PP002 = 7,
            VR = 8,
            PERSONAL003 = 9,
            PP003 = 10,
            MAGAZINE002 = 11,
            VRCOM = 12,
            PERSONAL004 = 13,
        }
    }

    public abstract class AFileSystemBase : IDisposable
    {
        protected bool is_disposed_;

        public abstract DLLFileSystem.Data object_data { get; }

        ~AFileSystemBase()
        {
            if (!this.is_disposed_)
                this.Dispose(false);
            this.is_disposed_ = true;
        }

        public abstract bool IsValid();

        public abstract AFileBase FileOpen(string f_strFileName);

        public abstract void AddAutoPathForAllFolder();

        public abstract string[] GetList(string f_str_path, AFileSystemBase.ListType type);

        public abstract bool IsExistentFile(string f_strFileName);

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        protected abstract void Dispose(bool is_release_managed_code);

        public enum ListType
        {
            TopFolder,
            AllFolder,
            TopFile,
            AllFile,
        }
    }

    public class DLLAnmParse : DLLClass
    {
        public DLLAnmParse.AnimationCurveDataList animation_curve_data_list = new DLLAnmParse.AnimationCurveDataList();
        public DLLAnmParse.AnimationCurveData animation_curve_data = new DLLAnmParse.AnimationCurveData();
        public DLLAnmParse.KeyFrameList key_frame_list = new DLLAnmParse.KeyFrameList();
        public DLLAnmParse.DelegateType.DLL_AnmParse_New Create;
        public DLLAnmParse.DelegateType.DLL_AnmParse_Delete Delete;
        public DLLAnmParse.DelegateType.DLL_AnmParse_Open Open;
        public DLLAnmParse.DelegateType.DLL_AnmParse_OpenByte OpenByte;
        public DLLAnmParse.DelegateType.DLL_AnmParse_Clear Clear;
        public DLLAnmParse.DelegateType.DLL_AnmParse_IsValid IsValid;
        public DLLAnmParse.DelegateType.DLL_AnmParse_GetAnimationCurveDataList GetAnimationCurveDataList;

        public override void ConnectFunction(BaseDllPack dll)
        {
            this.ConnectSupport<DLLAnmParse.DelegateType.DLL_AnmParse_New>(dll, out this.Create);
            this.ConnectSupport<DLLAnmParse.DelegateType.DLL_AnmParse_Delete>(dll, out this.Delete);
            this.ConnectSupport<DLLAnmParse.DelegateType.DLL_AnmParse_Open>(dll, out this.Open);
            this.ConnectSupport<DLLAnmParse.DelegateType.DLL_AnmParse_OpenByte>(dll, out this.OpenByte);
            this.ConnectSupport<DLLAnmParse.DelegateType.DLL_AnmParse_Clear>(dll, out this.Clear);
            this.ConnectSupport<DLLAnmParse.DelegateType.DLL_AnmParse_IsValid>(dll, out this.IsValid);
            this.ConnectSupport<DLLAnmParse.DelegateType.DLL_AnmParse_GetAnimationCurveDataList>(dll, out this.GetAnimationCurveDataList);
            this.ConnectSupport<DLLAnmParse.DelegateType.DLL_AnmParse_AnimationCurveDataList_Size>(dll, out this.animation_curve_data_list.Size);
            this.ConnectSupport<DLLAnmParse.DelegateType.DLL_AnmParse_AnimationCurveDataList_At>(dll, out this.animation_curve_data_list.At);
            this.ConnectSupport<DLLAnmParse.DelegateType.DLL_AnmParse_AnimationCurveData_GetPath>(dll, out this.animation_curve_data.GetPath);
            this.ConnectSupport<DLLAnmParse.DelegateType.DLL_AnmParse_AnimationCurveData_ComID>(dll, out this.animation_curve_data.GetComID);
            this.ConnectSupport<DLLAnmParse.DelegateType.DLL_AnmParse_AnimationCurveData_KeyFrameList>(dll, out this.animation_curve_data.KeyFrameList);
            this.ConnectSupport<DLLAnmParse.DelegateType.DLL_AnmParse_KeyFrameList_Size>(dll, out this.key_frame_list.Size);
            this.ConnectSupport<DLLAnmParse.DelegateType.DLL_AnmParse_KeyFrameList_At>(dll, out this.key_frame_list.At);
        }

        public struct Data
        {
            public IntPtr object_ptr;
        }

        public struct AnmKeyFrame
        {
            public float time;
            public float value;
            public float in_tangent;
            public float out_tangent;
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct DelegateType
        {
            public delegate void DLL_AnmParse_New(ref DLLAnmParse.Data dest);

            public delegate void DLL_AnmParse_Delete(ref DLLAnmParse.Data data);

            public delegate bool DLL_AnmParse_Open(ref DLLAnmParse.Data data, IntPtr file_obj_ptr, bool load_l_mune_anime, bool load_r_mune_anime);

            public delegate bool DLL_AnmParse_OpenByte(ref DLLAnmParse.Data data, IntPtr src, int src_size, bool load_l_mune_anime, bool load_r_mune_anime);

            public delegate void DLL_AnmParse_Clear(ref DLLAnmParse.Data data);

            public delegate bool DLL_AnmParse_IsValid(ref DLLAnmParse.Data data);

            public delegate IntPtr DLL_AnmParse_GetAnimationCurveDataList(ref DLLAnmParse.Data data);

            public delegate int DLL_AnmParse_AnimationCurveDataList_Size(IntPtr curve_datalist);

            public delegate IntPtr DLL_AnmParse_AnimationCurveDataList_At(IntPtr curve_datalist, int pos);

            public delegate IntPtr DLL_AnmParse_AnimationCurveData_GetPath(IntPtr curve_data);

            public delegate int DLL_AnmParse_AnimationCurveData_ComID(IntPtr curve_data);

            public delegate IntPtr DLL_AnmParse_AnimationCurveData_KeyFrameList(IntPtr curve_data);

            public delegate int DLL_AnmParse_KeyFrameList_Size(IntPtr key_framelist);

            public delegate void DLL_AnmParse_KeyFrameList_At(IntPtr key_framelist, int pos, ref DLLAnmParse.AnmKeyFrame dest);
        }

        public class AnimationCurveDataList
        {
            public DLLAnmParse.DelegateType.DLL_AnmParse_AnimationCurveDataList_Size Size;
            public DLLAnmParse.DelegateType.DLL_AnmParse_AnimationCurveDataList_At At;
        }

        public class AnimationCurveData
        {
            public DLLAnmParse.DelegateType.DLL_AnmParse_AnimationCurveData_GetPath GetPath;
            public DLLAnmParse.DelegateType.DLL_AnmParse_AnimationCurveData_ComID GetComID;
            public DLLAnmParse.DelegateType.DLL_AnmParse_AnimationCurveData_KeyFrameList KeyFrameList;
        }

        public class KeyFrameList
        {
            public DLLAnmParse.DelegateType.DLL_AnmParse_KeyFrameList_Size Size;
            public DLLAnmParse.DelegateType.DLL_AnmParse_KeyFrameList_At At;
        }
    }

    public class DLLColorPalette : DLLClass
    {
        public DLLColorPalette.DelegateType.DLL_Color_WriteColorTableToTexture WriteColorTableToTexture;
        public DLLColorPalette.DelegateType.DLL_Color_WriteColorShadowTableToTexture WriteColorShadowTableToTexture;
        public DLLColorPalette.DelegateType.DLL_Color_ConvertColor ConvertColor;
        public DLLColorPalette.DelegateType.DLL_Color_ConvertColorRect ConvertColorRect;
        public DLLColorPalette.DelegateType.DLL_Color_ConvertColorShadow ConvertColorShadow;
        public DLLColorPalette.DelegateType.DLL_Color_ConvertColorShadowRect ConvertColorShadowRect;
        public DLLColorPalette.DelegateType.DLL_Color_CreateByteDataFromTexture CreateByteDataFromTexture;

        public override void ConnectFunction(BaseDllPack dll)
        {
            this.ConnectSupport<DLLColorPalette.DelegateType.DLL_Color_WriteColorTableToTexture>(dll, out this.WriteColorTableToTexture);
            this.ConnectSupport<DLLColorPalette.DelegateType.DLL_Color_WriteColorShadowTableToTexture>(dll, out this.WriteColorShadowTableToTexture);
            this.ConnectSupport<DLLColorPalette.DelegateType.DLL_Color_ConvertColor>(dll, out this.ConvertColor);
            this.ConnectSupport<DLLColorPalette.DelegateType.DLL_Color_ConvertColorRect>(dll, out this.ConvertColorRect);
            this.ConnectSupport<DLLColorPalette.DelegateType.DLL_Color_ConvertColorShadow>(dll, out this.ConvertColorShadow);
            this.ConnectSupport<DLLColorPalette.DelegateType.DLL_Color_ConvertColorShadowRect>(dll, out this.ConvertColorShadowRect);
            this.ConnectSupport<DLLColorPalette.DelegateType.DLL_Color_CreateByteDataFromTexture>(dll, out this.CreateByteDataFromTexture);
        }

        public struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        public struct DllHslParam
        {
            public int brightness;
            public int contrast;
            public int hue;
            public int sat;
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct DelegateType
        {
            public delegate void DLL_Color_WriteColorTableToTexture(IntPtr device, ref DLLColorPalette.DllHslParam hsl_param, IntPtr dest_texture_ptr);

            public delegate void DLL_Color_WriteColorShadowTableToTexture(IntPtr device, ref DLLColorPalette.DllHslParam hsl_param, ref DLLColorPalette.DllHslParam hsl_shadow_param, int shadow_threshold, IntPtr dest_texture_ptr);

            public delegate void DLL_Color_ConvertColor(IntPtr device_data, ref DLLColorPalette.DllHslParam hsl_param, IntPtr pixel_data, IntPtr dest_texture_ptr);

            public delegate void DLL_Color_ConvertColorRect(IntPtr device_data, ref DLLColorPalette.DllHslParam hsl_param, IntPtr pixel_data, ref DLLColorPalette.Rect rect, IntPtr dest_texture_ptr);

            public delegate void DLL_Color_ConvertColorShadow(IntPtr device_data, ref DLLColorPalette.DllHslParam hsl_param, ref DLLColorPalette.DllHslParam hsl_shadow_param, int shadow_threshold, IntPtr pixel_data, IntPtr dest_texture_ptr);

            public delegate void DLL_Color_ConvertColorShadowRect(IntPtr device_data, ref DLLColorPalette.DllHslParam hsl_param, ref DLLColorPalette.DllHslParam hsl_shadow_param, int shadow_threshold, IntPtr pixel_data, ref DLLColorPalette.Rect rect, IntPtr dest_texture_ptr);

            public delegate DLLClass.ErrorCode DLL_Color_CreateByteDataFromTexture(IntPtr device, IntPtr texture_ptr, IntPtr dest);
        }
    }

    public class DLLCsvParser : DLLClass
    {
        public DLLCsvParser.DelegateType.DLL_CSV_CreateCsvParser CreateCsvParser;
        public DLLCsvParser.DelegateType.DLL_CSV_DeleteCsvParser DeleteCsvParser;
        public DLLCsvParser.DelegateType.DLL_CSV_Open Open;
        public DLLCsvParser.DelegateType.DLL_CSV_GetCellAsBinary GetCellAsBinary;
        public DLLCsvParser.DelegateType.DLL_CSV_GetCellAsString GetCellAsString;
        public DLLCsvParser.DelegateType.DLL_CSV_GetCellBool GetCellBool;
        public DLLCsvParser.DelegateType.DLL_CSV_GetCellAsInteger GetCellAsInteger;
        public DLLCsvParser.DelegateType.DLL_CSV_GetCellAsReal GetCellAsReal;
        public DLLCsvParser.DelegateType.DLL_CSV_GetDataSizeBinary GetDataSizeBinary;
        public DLLCsvParser.DelegateType.DLL_CSV_GetDataSizeString GetDataSizeString;
        public DLLCsvParser.DelegateType.DLL_CSV_IsCellToExistData IsCellToExistData;
        public DLLCsvParser.DelegateType.DLL_CSV_IsValid IsValid;
        public DLLCsvParser.DelegateType.DLL_CSV_GetMaxCellX GetMaxCellX;
        public DLLCsvParser.DelegateType.DLL_CSV_GetMaxCellY GetMaxCellY;

        public override void ConnectFunction(BaseDllPack dll)
        {
            this.ConnectSupport<DLLCsvParser.DelegateType.DLL_CSV_CreateCsvParser>(dll, out this.CreateCsvParser);
            this.ConnectSupport<DLLCsvParser.DelegateType.DLL_CSV_DeleteCsvParser>(dll, out this.DeleteCsvParser);
            this.ConnectSupport<DLLCsvParser.DelegateType.DLL_CSV_Open>(dll, out this.Open);
            this.ConnectSupport<DLLCsvParser.DelegateType.DLL_CSV_GetCellAsBinary>(dll, out this.GetCellAsBinary);
            this.ConnectSupport<DLLCsvParser.DelegateType.DLL_CSV_GetCellAsString>(dll, out this.GetCellAsString);
            this.ConnectSupport<DLLCsvParser.DelegateType.DLL_CSV_GetCellBool>(dll, out this.GetCellBool);
            this.ConnectSupport<DLLCsvParser.DelegateType.DLL_CSV_GetCellAsInteger>(dll, out this.GetCellAsInteger);
            this.ConnectSupport<DLLCsvParser.DelegateType.DLL_CSV_GetCellAsReal>(dll, out this.GetCellAsReal);
            this.ConnectSupport<DLLCsvParser.DelegateType.DLL_CSV_GetDataSizeBinary>(dll, out this.GetDataSizeBinary);
            this.ConnectSupport<DLLCsvParser.DelegateType.DLL_CSV_GetDataSizeString>(dll, out this.GetDataSizeString);
            this.ConnectSupport<DLLCsvParser.DelegateType.DLL_CSV_IsCellToExistData>(dll, out this.IsCellToExistData);
            this.ConnectSupport<DLLCsvParser.DelegateType.DLL_CSV_IsValid>(dll, out this.IsValid);
            this.ConnectSupport<DLLCsvParser.DelegateType.DLL_CSV_GetMaxCellX>(dll, out this.GetMaxCellX);
            this.ConnectSupport<DLLCsvParser.DelegateType.DLL_CSV_GetMaxCellY>(dll, out this.GetMaxCellY);
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct DelegateType
        {
            public delegate IntPtr DLL_CSV_CreateCsvParser();

            public delegate void DLL_CSV_DeleteCsvParser(IntPtr obj_ptr);

            public delegate bool DLL_CSV_Open(IntPtr obj_ptr, IntPtr file_obj_ptr);

            public delegate void DLL_CSV_GetCellAsBinary(IntPtr obj_ptr, int cell_x, int cell_y, IntPtr dest, int dest_buff_size);

            public delegate void DLL_CSV_GetCellAsString(IntPtr obj_ptr, int cell_x, int cell_y, IntPtr dest, int dest_buff_size);

            public delegate bool DLL_CSV_GetCellBool(IntPtr obj_ptr, int cell_x, int cell_y);

            public delegate int DLL_CSV_GetCellAsInteger(IntPtr obj_ptr, int cell_x, int cell_y);

            public delegate float DLL_CSV_GetCellAsReal(IntPtr obj_ptr, int cell_x, int cell_y);

            public delegate int DLL_CSV_GetDataSizeBinary(IntPtr obj_ptr, int cell_x, int cell_y);

            public delegate int DLL_CSV_GetDataSizeString(IntPtr obj_ptr, int cell_x, int cell_y);

            public delegate bool DLL_CSV_IsCellToExistData(IntPtr obj_ptr, int cell_x, int cell_y);

            public delegate bool DLL_CSV_IsValid(IntPtr obj_ptr);

            public delegate int DLL_CSV_GetMaxCellX(IntPtr obj_ptr);

            public delegate int DLL_CSV_GetMaxCellY(IntPtr obj_ptr);
        }
    }

    public class DLLFile : DLLClass
    {
        public DLLFile.DelegateType.DLL_File_IsValid IsValid;
        public DLLFile.DelegateType.DLL_File_SetSeek SetSeek;
        public DLLFile.DelegateType.DLL_File_Read Read;
        public DLLFile.DelegateType.DLL_File_GetTell GetTell;
        public DLLFile.DelegateType.DLL_File_GetSize GetSize;
        public DLLFile.DelegateType.DLL_File_CloseFile Close;

        public override void ConnectFunction(BaseDllPack dll)
        {
            this.ConnectSupport<DLLFile.DelegateType.DLL_File_IsValid>(dll, out this.IsValid);
            this.ConnectSupport<DLLFile.DelegateType.DLL_File_SetSeek>(dll, out this.SetSeek);
            this.ConnectSupport<DLLFile.DelegateType.DLL_File_Read>(dll, out this.Read);
            this.ConnectSupport<DLLFile.DelegateType.DLL_File_GetTell>(dll, out this.GetTell);
            this.ConnectSupport<DLLFile.DelegateType.DLL_File_GetSize>(dll, out this.GetSize);
            this.ConnectSupport<DLLFile.DelegateType.DLL_File_CloseFile>(dll, out this.Close);
        }

        public struct Data
        {
            public IntPtr object_pointer;
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct DelegateType
        {
            public delegate bool DLL_File_IsValid(ref DLLFile.Data data);

            public delegate bool DLL_File_SetSeek(ref DLLFile.Data data, long seek, bool absolute_move);

            public delegate long DLL_File_Read(ref DLLFile.Data data, IntPtr dest, long read_size);

            public delegate long DLL_File_GetTell(ref DLLFile.Data data);

            public delegate long DLL_File_GetSize(ref DLLFile.Data data);

            public delegate void DLL_File_CloseFile(ref DLLFile.Data obj);
        }
    }

    public class DLLFileSystem : DLLClass
    {
        public DLLFileSystem.DelegateType.DLL_FileSystem_CreateFileSystemWindows CreatemWindowsSystem;
        public DLLFileSystem.DelegateType.DLL_FileSystem_CreateFileSystemArchive CreateArchiveSystem;
        public DLLFileSystem.DelegateType.DLL_FileSystem_SetBaseDirectory SetBaseDirectory;
        public DLLFileSystem.DelegateType.DLL_FileSystem_AddFolder AddFolder;
        public DLLFileSystem.DelegateType.DLL_FileSystem_AddArchive AddArchive;
        public DLLFileSystem.DelegateType.DLL_FileSystem_AddAutoPath AddAutoPath;
        public DLLFileSystem.DelegateType.DLL_FileSystem_AddAutoPathForAllFolder AddAutoPathForAllFolder;
        public DLLFileSystem.DelegateType.DLL_FileSystem_CreateList CreateList;
        public DLLFileSystem.DelegateType.DLL_FileSystem_AtList AtList;
        public DLLFileSystem.DelegateType.DLL_FileSystem_DeleteList DeleteList;
        public DLLFileSystem.DelegateType.DLL_FileSystem_GetFile GetFile;
        public DLLFileSystem.DelegateType.DLL_FileSystem_IsValid IsValid;
        public DLLFileSystem.DelegateType.DLL_FileSystem_IsExistentFile IsExistentFile;
        public DLLFileSystem.DelegateType.DLL_FileSystem_DeleteFileSystem DeleteFileSystem;

        public override void ConnectFunction(BaseDllPack dll)
        {
            this.ConnectSupport<DLLFileSystem.DelegateType.DLL_FileSystem_CreateFileSystemWindows>(dll, out this.CreatemWindowsSystem);
            this.ConnectSupport<DLLFileSystem.DelegateType.DLL_FileSystem_CreateFileSystemArchive>(dll, out this.CreateArchiveSystem);
            this.ConnectSupport<DLLFileSystem.DelegateType.DLL_FileSystem_SetBaseDirectory>(dll, out this.SetBaseDirectory);
            this.ConnectSupport<DLLFileSystem.DelegateType.DLL_FileSystem_AddFolder>(dll, out this.AddFolder);
            this.ConnectSupport<DLLFileSystem.DelegateType.DLL_FileSystem_AddArchive>(dll, out this.AddArchive);
            this.ConnectSupport<DLLFileSystem.DelegateType.DLL_FileSystem_AddAutoPath>(dll, out this.AddAutoPath);
            this.ConnectSupport<DLLFileSystem.DelegateType.DLL_FileSystem_AddAutoPathForAllFolder>(dll, out this.AddAutoPathForAllFolder);
            this.ConnectSupport<DLLFileSystem.DelegateType.DLL_FileSystem_CreateList>(dll, out this.CreateList);
            this.ConnectSupport<DLLFileSystem.DelegateType.DLL_FileSystem_AtList>(dll, out this.AtList);
            this.ConnectSupport<DLLFileSystem.DelegateType.DLL_FileSystem_DeleteList>(dll, out this.DeleteList);
            this.ConnectSupport<DLLFileSystem.DelegateType.DLL_FileSystem_GetFile>(dll, out this.GetFile);
            this.ConnectSupport<DLLFileSystem.DelegateType.DLL_FileSystem_IsValid>(dll, out this.IsValid);
            this.ConnectSupport<DLLFileSystem.DelegateType.DLL_FileSystem_IsExistentFile>(dll, out this.IsExistentFile);
            this.ConnectSupport<DLLFileSystem.DelegateType.DLL_FileSystem_DeleteFileSystem>(dll, out this.DeleteFileSystem);
        }

        public struct Data
        {
            public IntPtr object_pointer;
            public int type;
        }

        public struct ListData
        {
            public int size;
            public IntPtr data;
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct DelegateType
        {
            public delegate void DLL_FileSystem_CreateFileSystemWindows(ref DLLFileSystem.Data obj);

            public delegate void DLL_FileSystem_CreateFileSystemArchive(ref DLLFileSystem.Data obj);

            public delegate bool DLL_FileSystem_SetBaseDirectory(ref DLLFileSystem.Data data, [MarshalAs(UnmanagedType.LPStr), In] string path);

            public delegate bool DLL_FileSystem_AddFolder(ref DLLFileSystem.Data obj, [MarshalAs(UnmanagedType.LPStr), In] string file_str);

            public delegate bool DLL_FileSystem_AddArchive(ref DLLFileSystem.Data data, [MarshalAs(UnmanagedType.LPStr), In] string path);

            public delegate bool DLL_FileSystem_AddAutoPath(ref DLLFileSystem.Data data, [MarshalAs(UnmanagedType.LPStr), In] string path);

            public delegate void DLL_FileSystem_AddAutoPathForAllFolder(ref DLLFileSystem.Data data);

            public delegate void DLL_FileSystem_CreateList(ref DLLFileSystem.Data data, [MarshalAs(UnmanagedType.LPStr), In] string folder_path, AFileSystemBase.ListType list_type, ref DLLFileSystem.ListData dest);

            public delegate int DLL_FileSystem_AtList(ref DLLFileSystem.ListData list_data, int at_num, IntPtr dest, int dest_buff_size);

            public delegate void DLL_FileSystem_DeleteList(ref DLLFileSystem.ListData list_data);

            public delegate bool DLL_FileSystem_GetFile(ref DLLFileSystem.Data obj, [MarshalAs(UnmanagedType.LPStr), In] string file_str, ref DLLFile.Data dest);

            public delegate bool DLL_FileSystem_IsValid(ref DLLFileSystem.Data data);

            public delegate bool DLL_FileSystem_IsExistentFile(ref DLLFileSystem.Data obj, [MarshalAs(UnmanagedType.LPStr), In] string file_str);

            public delegate void DLL_FileSystem_DeleteFileSystem(ref DLLFileSystem.Data obj);
        }
    }

    public class DLLKagScript : DLLClass
    {
        public DLLKagScript.DelegateType.DLL_KAG_GetUniqueIDFromBasicKagScriptPtr GetUniqueIDFromBasicKagScriptPtr;
        public DLLKagScript.DelegateType.DLL_KAG_Create Create;
        public DLLKagScript.DelegateType.DLL_KAG_Delete Delete;
        public DLLKagScript.DelegateType.DLL_KAG_ClearCallStack ClearCallStack;
        public DLLKagScript.DelegateType.DLL_KAG_SetReplaceFunction SetReplaceFunction;
        public DLLKagScript.DelegateType.DLL_KAG_SetOnScenarioLoadFunction SetOnScenarioLoadFunction;
        public DLLKagScript.DelegateType.DLL_KAG_GetKey GetKey;
        public DLLKagScript.DelegateType.DLL_KAG_AddTag AddTag;
        public DLLKagScript.DelegateType.DLL_KAG_RemoveTag RemoveTag;
        public DLLKagScript.DelegateType.DLL_KAG_SetOnLabelCallBackFunction SetOnLabelCallBack;
        public DLLKagScript.DelegateType.DLL_KAG_LoadScenario LoadScenario;
        public DLLKagScript.DelegateType.DLL_KAG_LoadScenarioString LoadScenarioString;
        public DLLKagScript.DelegateType.DLL_KAG_GoToLabel GoToLabel;
        public DLLKagScript.DelegateType.DLL_KAG_TextClear TextClear;
        public DLLKagScript.DelegateType.DLL_KAG_Exec Exec;
        public DLLKagScript.DelegateType.DLL_KAG_ClearScnearioCache ClearScnearioCache;
        public DLLKagScript.DelegateType.DLL_KAG_IsExecScenario IsExecScenario;
        public DLLKagScript.DelegateType.DLL_KAG_GetStoragename GetCurrentFileName;
        public DLLKagScript.DelegateType.DLL_KAG_GetCurrentLabel GetCurrentLabel;
        public DLLKagScript.DelegateType.DLL_KAG_GetCurrentLine GetCurrentLine;
        public DLLKagScript.DelegateType.DLL_KAG_GetText GetText;
        public DLLKagScript.DelegateType.DLL_KAG_AddFinishFile AddFinishFile;
        public DLLKagScript.DelegateType.DLL_KAG_GetFinishFile GetFinishFile;
        public DLLKagScript.DelegateType.DLL_KAG_AddRecordLabel AddRecordLabel;
        public DLLKagScript.DelegateType.DLL_KAG_GetRecordLabel GetRecordLabel;
        public DLLKagScript.DelegateType.DLL_KAG_CreateSerializeData CreateSerializeData;
        public DLLKagScript.DelegateType.DLL_KAG_GetSerializeDataSize GetSerializeDataSize;
        public DLLKagScript.DelegateType.DLL_KAG_WriteSerializeData WriteSerializeData;
        public DLLKagScript.DelegateType.DLL_KAG_ReleaseSerializeData ReleaseSerializeData;
        public DLLKagScript.DelegateType.DLL_KAG_Deserialize Deserialize;
        public DLLKagScript.DelegateType.DLL_KAG_GetUniqueID GetUniqueID;

        public override void ConnectFunction(BaseDllPack dll)
        {
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_GetUniqueIDFromBasicKagScriptPtr>(dll, out this.GetUniqueIDFromBasicKagScriptPtr);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_Create>(dll, out this.Create);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_Delete>(dll, out this.Delete);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_ClearCallStack>(dll, out this.ClearCallStack);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_GetKey>(dll, out this.GetKey);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_AddTag>(dll, out this.AddTag);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_RemoveTag>(dll, out this.RemoveTag);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_SetReplaceFunction>(dll, out this.SetReplaceFunction);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_SetOnScenarioLoadFunction>(dll, out this.SetOnScenarioLoadFunction);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_SetOnLabelCallBackFunction>(dll, out this.SetOnLabelCallBack);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_LoadScenario>(dll, out this.LoadScenario);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_LoadScenarioString>(dll, out this.LoadScenarioString);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_GoToLabel>(dll, out this.GoToLabel);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_TextClear>(dll, out this.TextClear);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_Exec>(dll, out this.Exec);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_ClearScnearioCache>(dll, out this.ClearScnearioCache);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_IsExecScenario>(dll, out this.IsExecScenario);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_GetStoragename>(dll, out this.GetCurrentFileName);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_GetCurrentLabel>(dll, out this.GetCurrentLabel);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_GetCurrentLine>(dll, out this.GetCurrentLine);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_GetText>(dll, out this.GetText);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_AddFinishFile>(dll, out this.AddFinishFile);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_GetFinishFile>(dll, out this.GetFinishFile);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_AddRecordLabel>(dll, out this.AddRecordLabel);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_GetRecordLabel>(dll, out this.GetRecordLabel);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_CreateSerializeData>(dll, out this.CreateSerializeData);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_GetSerializeDataSize>(dll, out this.GetSerializeDataSize);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_WriteSerializeData>(dll, out this.WriteSerializeData);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_ReleaseSerializeData>(dll, out this.ReleaseSerializeData);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_Deserialize>(dll, out this.Deserialize);
            this.ConnectSupport<DLLKagScript.DelegateType.DLL_KAG_GetUniqueID>(dll, out this.GetUniqueID);
        }

        public struct Data
        {
            public IntPtr object_ptr;
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct DelegateType
        {
            public delegate ulong DLL_KAG_GetUniqueIDFromBasicKagScriptPtr(IntPtr basic_kagscript_ptr);

            public delegate void DLL_KAG_Create(ref DLLTJSScript.Data tjs_data, ref DLLKagScript.Data data);

            public delegate void DLL_KAG_Delete(ref DLLKagScript.Data data);

            public delegate void DLL_KAG_ClearCallStack(ref DLLKagScript.Data data);

            public delegate void DLL_KAG_SetReplaceFunction(ref DLLKagScript.Data data, DLLKagScript.ReplaceCallBack call_back);

            public delegate void DLL_KAG_SetOnScenarioLoadFunction(ref DLLKagScript.Data data, DLLKagScript.OnScenarioLoadCallBack call_back);

            public delegate ulong DLL_KAG_GetKey(ref DLLKagScript.Data data, [MarshalAs(UnmanagedType.LPStr), In] string tag_name);

            public delegate ulong DLL_KAG_AddTag(ref DLLKagScript.Data data, [MarshalAs(UnmanagedType.LPStr), In] string tag_name, DLLKagScript.KagCallBack call_back_del);

            public delegate bool DLL_KAG_RemoveTag(ref DLLKagScript.Data data, [MarshalAs(UnmanagedType.LPStr), In] string tag_name);

            public delegate void DLL_KAG_SetOnLabelCallBackFunction(ref DLLKagScript.Data data, DLLKagScript.OnLabelCallBack call_back_delgate);

            public delegate void DLL_KAG_LoadScenario(ref DLLKagScript.Data data, [MarshalAs(UnmanagedType.LPStr), In] string file_name);

            public delegate void DLL_KAG_LoadScenarioString(ref DLLKagScript.Data data, [MarshalAs(UnmanagedType.LPStr), In] string scenario_str);

            public delegate void DLL_KAG_GoToLabel(ref DLLKagScript.Data data, [MarshalAs(UnmanagedType.LPStr), In] string label_name);

            public delegate void DLL_KAG_TextClear(ref DLLKagScript.Data data);

            public delegate bool DLL_KAG_Exec(ref DLLKagScript.Data data);

            public delegate void DLL_KAG_ClearScnearioCache(ref DLLKagScript.Data data);

            public delegate bool DLL_KAG_IsExecScenario(ref DLLKagScript.Data data);

            public delegate void DLL_KAG_GetStoragename(ref DLLKagScript.Data data, IntPtr dest, int dest_buff_size);

            public delegate void DLL_KAG_GetCurrentLabel(ref DLLKagScript.Data data, IntPtr dest, int dest_buff_size);

            public delegate int DLL_KAG_GetCurrentLine(ref DLLKagScript.Data data);

            public delegate bool DLL_KAG_GetText(ref DLLKagScript.Data data, IntPtr dest, int dest_buff_size);

            public delegate void DLL_KAG_AddFinishFile(ref DLLKagScript.Data data, [MarshalAs(UnmanagedType.LPStr), In] string file_name);

            public delegate bool DLL_KAG_GetFinishFile(ref DLLKagScript.Data data, [MarshalAs(UnmanagedType.LPStr), In] string file_name);

            public delegate void DLL_KAG_AddRecordLabel(ref DLLKagScript.Data data, [MarshalAs(UnmanagedType.LPStr), In] string file_name, [MarshalAs(UnmanagedType.LPStr), In] string label_name);

            public delegate bool DLL_KAG_GetRecordLabel(ref DLLKagScript.Data data, [MarshalAs(UnmanagedType.LPStr), In] string file_name, [MarshalAs(UnmanagedType.LPStr), In] string label_name);

            public delegate IntPtr DLL_KAG_CreateSerializeData(ref DLLKagScript.Data data);

            public delegate uint DLL_KAG_GetSerializeDataSize(IntPtr serialize_ptr);

            public delegate void DLL_KAG_WriteSerializeData(IntPtr dest, IntPtr serialize_ptr);

            public delegate void DLL_KAG_ReleaseSerializeData(IntPtr serialize_ptr);

            public delegate void DLL_KAG_Deserialize(ref DLLKagScript.Data data, IntPtr serialize_data);

            public delegate ulong DLL_KAG_GetUniqueID(ref DLLKagScript.Data data);
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public delegate bool KagCallBack(IntPtr var_ptr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ReplaceCallBack(IntPtr basic_kagscript_ptr, [MarshalAs(UnmanagedType.LPStr), In] string filename, IntPtr dest, int dest_size);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnScenarioLoadCallBack(IntPtr basic_kagscript_ptr, [MarshalAs(UnmanagedType.LPStr), In] string filename, [MarshalAs(UnmanagedType.LPStr), In] string labelname);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void OnLabelCallBack(IntPtr basic_kagscript_ptr, [MarshalAs(UnmanagedType.U1)] bool label_readed);
    }

    public class DLLKagTagSupport : DLLClass
    {
        public DLLKagTagSupport.DelegateType.DLL_KAG_TAG_IsValid IsValid;
        public DLLKagTagSupport.DelegateType.DLL_KAG_TAG_GetTagProperty GetTagProperty;
        public DLLKagTagSupport.DelegateType.DLL_KAG_TAG_GetTagKey GetTagKey;
        public DLLKagTagSupport.DelegateType.DLL_KAG_TAG_GetClassUniqueid GetClassUniqueid;
        public DLLKagTagSupport.DelegateType.DLL_KAG_TAG_CreateTagList CreateTagList;
        public DLLKagTagSupport.DelegateType.DLL_KAG_TAG_GetListCount GetListCount;
        public DLLKagTagSupport.DelegateType.DLL_KAG_TAG_GetListNameAt GetListNameAt;
        public DLLKagTagSupport.DelegateType.DLL_KAG_TAG_GetListElmAt GetListElmAt;

        public override void ConnectFunction(BaseDllPack dll)
        {
            this.ConnectSupport<DLLKagTagSupport.DelegateType.DLL_KAG_TAG_IsValid>(dll, out this.IsValid);
            this.ConnectSupport<DLLKagTagSupport.DelegateType.DLL_KAG_TAG_GetTagProperty>(dll, out this.GetTagProperty);
            this.ConnectSupport<DLLKagTagSupport.DelegateType.DLL_KAG_TAG_GetTagKey>(dll, out this.GetTagKey);
            this.ConnectSupport<DLLKagTagSupport.DelegateType.DLL_KAG_TAG_GetClassUniqueid>(dll, out this.GetClassUniqueid);
            this.ConnectSupport<DLLKagTagSupport.DelegateType.DLL_KAG_TAG_CreateTagList>(dll, out this.CreateTagList);
            this.ConnectSupport<DLLKagTagSupport.DelegateType.DLL_KAG_TAG_GetListCount>(dll, out this.GetListCount);
            this.ConnectSupport<DLLKagTagSupport.DelegateType.DLL_KAG_TAG_GetListNameAt>(dll, out this.GetListNameAt);
            this.ConnectSupport<DLLKagTagSupport.DelegateType.DLL_KAG_TAG_GetListElmAt>(dll, out this.GetListElmAt);
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct DelegateType
        {
            public delegate bool DLL_KAG_TAG_IsValid(IntPtr ptr, [MarshalAs(UnmanagedType.LPStr), In] string tag_name);

            public delegate bool DLL_KAG_TAG_GetTagProperty(IntPtr ptr, [MarshalAs(UnmanagedType.LPStr), In] string tag_name, ref DLLTJSVariant.Data var_data);

            public delegate ulong DLL_KAG_TAG_GetTagKey(IntPtr ptr);

            public delegate ulong DLL_KAG_TAG_GetClassUniqueid(IntPtr ptr);

            public delegate void DLL_KAG_TAG_CreateTagList(IntPtr ptr);

            public delegate int DLL_KAG_TAG_GetListCount(IntPtr ptr);

            public delegate void DLL_KAG_TAG_GetListNameAt(IntPtr ptr, int no, IntPtr dest, int dest_buff_size);

            public delegate void DLL_KAG_TAG_GetListElmAt(IntPtr ptr, int no, IntPtr dest, int dest_buff_size);
        }
    }

public class DLLMenuParse : DLLClass
    {
        public DLLMenuParse.DelegateType.DLL_MenuParse_New Create;
        public DLLMenuParse.DelegateType.DLL_MenuParse_Delete Delete;
        public DLLMenuParse.DelegateType.DLL_MenuParse_Open Open;
        public DLLMenuParse.DelegateType.DLL_MenuParse_OpenByte OpenByte;
        public DLLMenuParse.DelegateType.DLL_MenuParse_GetHeaderCheck GetHeaderCheck;
        public DLLMenuParse.DelegateType.DLL_MenuParse_GetVersion GetVersion;
        public DLLMenuParse.DelegateType.DLL_MenuParse_GetSrcFileName GetSrcFileName;
        public DLLMenuParse.DelegateType.DLL_MenuParse_GetItemName GetItemName;
        public DLLMenuParse.DelegateType.DLL_MenuParse_GetCategoryName GetCategoryName;
        public DLLMenuParse.DelegateType.DLL_MenuParse_GetInfoText GetInfoText;
        public DLLMenuParse.DelegateType.DLL_MenuParse_GetMenuName GetMenuName;
        public DLLMenuParse.DelegateType.DLL_MenuParse_GetItemInfoText GetItemInfoText;
        public DLLMenuParse.DelegateType.DLL_MenuParse_GetCategoryMpnText GetCategoryMpnText;
        public DLLMenuParse.DelegateType.DLL_MenuParse_GetCategoryMpn GetCategoryMpn;
        public DLLMenuParse.DelegateType.DLL_MenuParse_GetColorSetMpn GetColorSetMpn;
        public DLLMenuParse.DelegateType.DLL_MenuParse_GetMenuNameInColorSet GetMenuNameInColorSet;
        public DLLMenuParse.DelegateType.DLL_MenuParse_GetMultiColorId GetMultiColorId;
        public DLLMenuParse.DelegateType.DLL_MenuParse_GetIconS GetIconS;
        public DLLMenuParse.DelegateType.DLL_MenuParse_GetSaveItem GetSaveItem;
        public DLLMenuParse.DelegateType.DLL_MenuParse_GetBoDelOnly GetBoDelOnly;
        public DLLMenuParse.DelegateType.DLL_MenuParse_GetPriorityText GetPriorityText;
        public DLLMenuParse.DelegateType.DLL_MenuParse_GetIsMan GetIsMan;

        public override void ConnectFunction(BaseDllPack dll)
        {
            this.ConnectSupport<DLLMenuParse.DelegateType.DLL_MenuParse_New>(dll, out this.Create);
            this.ConnectSupport<DLLMenuParse.DelegateType.DLL_MenuParse_Delete>(dll, out this.Delete);
            this.ConnectSupport<DLLMenuParse.DelegateType.DLL_MenuParse_Open>(dll, out this.Open);
            this.ConnectSupport<DLLMenuParse.DelegateType.DLL_MenuParse_OpenByte>(dll, out this.OpenByte);
            this.ConnectSupport<DLLMenuParse.DelegateType.DLL_MenuParse_GetHeaderCheck>(dll, out this.GetHeaderCheck);
            this.ConnectSupport<DLLMenuParse.DelegateType.DLL_MenuParse_GetVersion>(dll, out this.GetVersion);
            this.ConnectSupport<DLLMenuParse.DelegateType.DLL_MenuParse_GetSrcFileName>(dll, out this.GetSrcFileName);
            this.ConnectSupport<DLLMenuParse.DelegateType.DLL_MenuParse_GetItemName>(dll, out this.GetItemName);
            this.ConnectSupport<DLLMenuParse.DelegateType.DLL_MenuParse_GetCategoryName>(dll, out this.GetCategoryName);
            this.ConnectSupport<DLLMenuParse.DelegateType.DLL_MenuParse_GetInfoText>(dll, out this.GetInfoText);
            this.ConnectSupport<DLLMenuParse.DelegateType.DLL_MenuParse_GetMenuName>(dll, out this.GetMenuName);
            this.ConnectSupport<DLLMenuParse.DelegateType.DLL_MenuParse_GetItemInfoText>(dll, out this.GetItemInfoText);
            this.ConnectSupport<DLLMenuParse.DelegateType.DLL_MenuParse_GetCategoryMpnText>(dll, out this.GetCategoryMpnText);
            this.ConnectSupport<DLLMenuParse.DelegateType.DLL_MenuParse_GetCategoryMpn>(dll, out this.GetCategoryMpn);
            this.ConnectSupport<DLLMenuParse.DelegateType.DLL_MenuParse_GetColorSetMpn>(dll, out this.GetColorSetMpn);
            this.ConnectSupport<DLLMenuParse.DelegateType.DLL_MenuParse_GetMenuNameInColorSet>(dll, out this.GetMenuNameInColorSet);
            this.ConnectSupport<DLLMenuParse.DelegateType.DLL_MenuParse_GetMultiColorId>(dll, out this.GetMultiColorId);
            this.ConnectSupport<DLLMenuParse.DelegateType.DLL_MenuParse_GetIconS>(dll, out this.GetIconS);
            this.ConnectSupport<DLLMenuParse.DelegateType.DLL_MenuParse_GetSaveItem>(dll, out this.GetSaveItem);
            this.ConnectSupport<DLLMenuParse.DelegateType.DLL_MenuParse_GetBoDelOnly>(dll, out this.GetBoDelOnly);
            this.ConnectSupport<DLLMenuParse.DelegateType.DLL_MenuParse_GetPriorityText>(dll, out this.GetPriorityText);
            this.ConnectSupport<DLLMenuParse.DelegateType.DLL_MenuParse_GetIsMan>(dll, out this.GetIsMan);
        }

        public struct Data
        {
            public IntPtr object_ptr;
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct DelegateType
        {
            public delegate void DLL_MenuParse_New(ref DLLMenuParse.Data dest);

            public delegate void DLL_MenuParse_Delete(ref DLLMenuParse.Data data);

            public delegate bool DLL_MenuParse_Open(ref DLLMenuParse.Data data, IntPtr file_obj_ptr);

            public delegate bool DLL_MenuParse_OpenByte(ref DLLMenuParse.Data data, IntPtr src, int src_size);

            public delegate bool DLL_MenuParse_GetHeaderCheck(ref DLLMenuParse.Data data);

            public delegate int DLL_MenuParse_GetVersion(ref DLLMenuParse.Data data);

            public delegate IntPtr DLL_MenuParse_GetSrcFileName(ref DLLMenuParse.Data data);

            public delegate IntPtr DLL_MenuParse_GetItemName(ref DLLMenuParse.Data data);

            public delegate IntPtr DLL_MenuParse_GetCategoryName(ref DLLMenuParse.Data data);

            public delegate IntPtr DLL_MenuParse_GetInfoText(ref DLLMenuParse.Data data);

            public delegate IntPtr DLL_MenuParse_GetMenuName(ref DLLMenuParse.Data data);

            public delegate IntPtr DLL_MenuParse_GetItemInfoText(ref DLLMenuParse.Data data);

            public delegate IntPtr DLL_MenuParse_GetCategoryMpnText(ref DLLMenuParse.Data data);

            public delegate int DLL_MenuParse_GetCategoryMpn(ref DLLMenuParse.Data data);

            public delegate int DLL_MenuParse_GetColorSetMpn(ref DLLMenuParse.Data data);

            public delegate IntPtr DLL_MenuParse_GetMenuNameInColorSet(ref DLLMenuParse.Data data);

            public delegate int DLL_MenuParse_GetMultiColorId(ref DLLMenuParse.Data data);

            public delegate IntPtr DLL_MenuParse_GetIconS(ref DLLMenuParse.Data data);

            public delegate IntPtr DLL_MenuParse_GetSaveItem(ref DLLMenuParse.Data data);

            public delegate bool DLL_MenuParse_GetBoDelOnly(ref DLLMenuParse.Data data);

            public delegate IntPtr DLL_MenuParse_GetPriorityText(ref DLLMenuParse.Data data);

            public delegate bool DLL_MenuParse_GetIsMan(ref DLLMenuParse.Data data);
        }
    }

    public class DLLNativeArray : DLLClass
    {
        public DLLNativeArray.DelegateType.DLL_NativeArray_GetSize GetSize;
        public DLLNativeArray.DelegateType.DLL_NativeArray_Delete Delete;
        public DLLNativeArray.DelegateType.DLL_NativeArray_Float_Create FloatCreate;
        public DLLNativeArray.DelegateType.DLL_NativeArray_Float_CreateCopy FloatCreateCopy;
        public DLLNativeArray.DelegateType.DLL_NativeArray_Float_CopyTo FloatCopyTo;
        public DLLNativeArray.DelegateType.DLL_NativeArray_Float_Set FloatSet;
        public DLLNativeArray.DelegateType.DLL_NativeArray_Float_At FloatAt;
        public DLLNativeArray.DelegateType.DLL_NativeArray_Int_Create IntCreate;
        public DLLNativeArray.DelegateType.DLL_NativeArray_Int_CreateCopy IntCreateCopy;
        public DLLNativeArray.DelegateType.DLL_NativeArray_Int_CopyTo IntCopyTo;
        public DLLNativeArray.DelegateType.DLL_NativeArray_Int_Set IntSet;
        public DLLNativeArray.DelegateType.DLL_NativeArray_Int_At IntAt;
        public DLLNativeArray.DelegateType.DLL_NativeArray_Vector3_Create Vector3Create;
        public DLLNativeArray.DelegateType.DLL_NativeArray_Vector3_CreateCopy Vector3CreateCopy;
        public DLLNativeArray.DelegateType.DLL_NativeArray_Vector3_CopyTo Vector3CopyTo;
        public DLLNativeArray.DelegateType.DLL_NativeArray_Vector3_SetXYZ Vector3SetXYZ;
        public DLLNativeArray.DelegateType.DLL_NativeArray_Vector3_AtX Vector3AtX;
        public DLLNativeArray.DelegateType.DLL_NativeArray_Vector3_AtY Vector3AtY;
        public DLLNativeArray.DelegateType.DLL_NativeArray_Vector3_AtZ Vector3AtZ;

        public override void ConnectFunction(BaseDllPack dll)
        {
            this.ConnectSupport<DLLNativeArray.DelegateType.DLL_NativeArray_GetSize>(dll, out this.GetSize);
            this.ConnectSupport<DLLNativeArray.DelegateType.DLL_NativeArray_Delete>(dll, out this.Delete);
            this.ConnectSupport<DLLNativeArray.DelegateType.DLL_NativeArray_Float_Create>(dll, out this.FloatCreate);
            this.ConnectSupport<DLLNativeArray.DelegateType.DLL_NativeArray_Float_CreateCopy>(dll, out this.FloatCreateCopy);
            this.ConnectSupport<DLLNativeArray.DelegateType.DLL_NativeArray_Float_CopyTo>(dll, out this.FloatCopyTo);
            this.ConnectSupport<DLLNativeArray.DelegateType.DLL_NativeArray_Float_Set>(dll, out this.FloatSet);
            this.ConnectSupport<DLLNativeArray.DelegateType.DLL_NativeArray_Float_At>(dll, out this.FloatAt);
            this.ConnectSupport<DLLNativeArray.DelegateType.DLL_NativeArray_Int_Create>(dll, out this.IntCreate);
            this.ConnectSupport<DLLNativeArray.DelegateType.DLL_NativeArray_Int_CreateCopy>(dll, out this.IntCreateCopy);
            this.ConnectSupport<DLLNativeArray.DelegateType.DLL_NativeArray_Int_CopyTo>(dll, out this.IntCopyTo);
            this.ConnectSupport<DLLNativeArray.DelegateType.DLL_NativeArray_Int_Set>(dll, out this.IntSet);
            this.ConnectSupport<DLLNativeArray.DelegateType.DLL_NativeArray_Int_At>(dll, out this.IntAt);
            this.ConnectSupport<DLLNativeArray.DelegateType.DLL_NativeArray_Vector3_Create>(dll, out this.Vector3Create);
            this.ConnectSupport<DLLNativeArray.DelegateType.DLL_NativeArray_Vector3_CreateCopy>(dll, out this.Vector3CreateCopy);
            this.ConnectSupport<DLLNativeArray.DelegateType.DLL_NativeArray_Vector3_CopyTo>(dll, out this.Vector3CopyTo);
            this.ConnectSupport<DLLNativeArray.DelegateType.DLL_NativeArray_Vector3_SetXYZ>(dll, out this.Vector3SetXYZ);
            this.ConnectSupport<DLLNativeArray.DelegateType.DLL_NativeArray_Vector3_AtX>(dll, out this.Vector3AtX);
            this.ConnectSupport<DLLNativeArray.DelegateType.DLL_NativeArray_Vector3_AtY>(dll, out this.Vector3AtY);
            this.ConnectSupport<DLLNativeArray.DelegateType.DLL_NativeArray_Vector3_AtZ>(dll, out this.Vector3AtZ);
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct DelegateType
        {
            public delegate int DLL_NativeArray_GetSize(IntPtr data_ptr);

            public delegate void DLL_NativeArray_Delete(IntPtr data_ptr);

            public delegate IntPtr DLL_NativeArray_Float_Create(int size);

            public delegate IntPtr DLL_NativeArray_Float_CreateCopy(IntPtr src_data_ptr);

            public delegate void DLL_NativeArray_Float_CopyTo(IntPtr data_ptr, IntPtr copy_dest_data_ptr);

            public delegate void DLL_NativeArray_Float_Set(IntPtr data_ptr, int pos, float value);

            public delegate float DLL_NativeArray_Float_At(IntPtr data_ptr, int pos);

            public delegate IntPtr DLL_NativeArray_Int_Create(int size);

            public delegate IntPtr DLL_NativeArray_Int_CreateCopy(IntPtr src_data_ptr);

            public delegate void DLL_NativeArray_Int_CopyTo(IntPtr data_ptr, IntPtr copy_dest_data_ptr);

            public delegate void DLL_NativeArray_Int_Set(IntPtr data_ptr, int pos, int value);

            public delegate int DLL_NativeArray_Int_At(IntPtr data_ptr, int pos);

            public delegate IntPtr DLL_NativeArray_Vector3_Create(int size);

            public delegate IntPtr DLL_NativeArray_Vector3_CreateCopy(IntPtr src_data_ptr);

            public delegate void DLL_NativeArray_Vector3_CopyTo(IntPtr data_ptr, IntPtr copy_dest_data_ptr);

            public delegate void DLL_NativeArray_Vector3_SetXYZ(IntPtr data_ptr, int pos, float x, float y, float z);

            public delegate float DLL_NativeArray_Vector3_AtX(IntPtr data_ptr, int pos);

            public delegate float DLL_NativeArray_Vector3_AtY(IntPtr data_ptr, int pos);

            public delegate float DLL_NativeArray_Vector3_AtZ(IntPtr data_ptr, int pos);
        }
    }

    public class DLLPluginData : DLLClass
    {
        public DLLPluginData.DelegateType.DLL_PLUGIN_CreatePluginData CreatePluginData;
        public DLLPluginData.DelegateType.DLL_PLUGIN_IsEnabled IsEnabled;
        public DLLPluginData.DelegateType.DLL_PLUGIN_DeletePluginData DeletePluginData;

        public override void ConnectFunction(BaseDllPack dll)
        {
            this.ConnectSupport<DLLPluginData.DelegateType.DLL_PLUGIN_CreatePluginData>(dll, out this.CreatePluginData);
            this.ConnectSupport<DLLPluginData.DelegateType.DLL_PLUGIN_IsEnabled>(dll, out this.IsEnabled);
            this.ConnectSupport<DLLPluginData.DelegateType.DLL_PLUGIN_DeletePluginData>(dll, out this.DeletePluginData);
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct DelegateType
        {
            public delegate IntPtr DLL_PLUGIN_CreatePluginData(IntPtr filesystem_ptr);

            public delegate bool DLL_PLUGIN_IsEnabled(IntPtr data_ptr, int plugin_type);

            public delegate void DLL_PLUGIN_DeletePluginData(IntPtr data_ptr);
        }
    }

    public class DLLSoundReaderOGG : DLLClass
    {
        public DLLSoundReaderOGG.DelegateType.DLL_OGG_CreateSoundReaderOGG CreateSoundReaderOGG;
        public DLLSoundReaderOGG.DelegateType.DLL_OGG_DeleteSoundReaderOGG DeleteSoundReaderOGG;
        public DLLSoundReaderOGG.DelegateType.DLL_OGG_OpenFile OpenFile;
        public DLLSoundReaderOGG.DelegateType.DLL_OGG_CloseFile CloseFile;
        public DLLSoundReaderOGG.DelegateType.DLL_OGG_IsOpenFile IsOpenFile;
        public DLLSoundReaderOGG.DelegateType.DLL_OGG_Read Read;
        public DLLSoundReaderOGG.DelegateType.DLL_OGG_ReadUnity ReadUnity;
        public DLLSoundReaderOGG.DelegateType.DLL_OGG_SeekSample SeekSample;
        public DLLSoundReaderOGG.DelegateType.DLL_OGG_GetChannels GetChannels;
        public DLLSoundReaderOGG.DelegateType.DLL_OGG_GetSampleRate GetSampleRate;
        public DLLSoundReaderOGG.DelegateType.DLL_OGG_GetSampleBit GetSampleBit;
        public DLLSoundReaderOGG.DelegateType.DLL_OGG_GetTotalSampleLengs GetTotalSampleLengs;

        public override void ConnectFunction(BaseDllPack dll)
        {
            this.ConnectSupport<DLLSoundReaderOGG.DelegateType.DLL_OGG_CreateSoundReaderOGG>(dll, out this.CreateSoundReaderOGG);
            this.ConnectSupport<DLLSoundReaderOGG.DelegateType.DLL_OGG_DeleteSoundReaderOGG>(dll, out this.DeleteSoundReaderOGG);
            this.ConnectSupport<DLLSoundReaderOGG.DelegateType.DLL_OGG_OpenFile>(dll, out this.OpenFile);
            this.ConnectSupport<DLLSoundReaderOGG.DelegateType.DLL_OGG_CloseFile>(dll, out this.CloseFile);
            this.ConnectSupport<DLLSoundReaderOGG.DelegateType.DLL_OGG_IsOpenFile>(dll, out this.IsOpenFile);
            this.ConnectSupport<DLLSoundReaderOGG.DelegateType.DLL_OGG_Read>(dll, out this.Read);
            this.ConnectSupport<DLLSoundReaderOGG.DelegateType.DLL_OGG_ReadUnity>(dll, out this.ReadUnity);
            this.ConnectSupport<DLLSoundReaderOGG.DelegateType.DLL_OGG_SeekSample>(dll, out this.SeekSample);
            this.ConnectSupport<DLLSoundReaderOGG.DelegateType.DLL_OGG_GetChannels>(dll, out this.GetChannels);
            this.ConnectSupport<DLLSoundReaderOGG.DelegateType.DLL_OGG_GetSampleRate>(dll, out this.GetSampleRate);
            this.ConnectSupport<DLLSoundReaderOGG.DelegateType.DLL_OGG_GetSampleBit>(dll, out this.GetSampleBit);
            this.ConnectSupport<DLLSoundReaderOGG.DelegateType.DLL_OGG_GetTotalSampleLengs>(dll, out this.GetTotalSampleLengs);
        }

        public struct Data
        {
            public IntPtr object_ptr;
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct DelegateType
        {
            public delegate void DLL_OGG_CreateSoundReaderOGG(ref DLLFileSystem.Data file_system_data, ref DLLSoundReaderOGG.Data dest);

            public delegate void DLL_OGG_DeleteSoundReaderOGG(ref DLLSoundReaderOGG.Data data);

            public delegate bool DLL_OGG_IsOpenFile(ref DLLSoundReaderOGG.Data data);

            public delegate void DLL_OGG_OpenFile(ref DLLSoundReaderOGG.Data data, [MarshalAs(UnmanagedType.LPStr), In] string file_name);

            public delegate void DLL_OGG_CloseFile(ref DLLSoundReaderOGG.Data data);

            public delegate uint DLL_OGG_Read(ref DLLSoundReaderOGG.Data data, IntPtr dest, uint read_size);

            public delegate void DLL_OGG_ReadUnity(ref DLLSoundReaderOGG.Data data, IntPtr dest, uint sample_num);

            public delegate void DLL_OGG_SeekSample(ref DLLSoundReaderOGG.Data data, uint seek_sample_pos, int absolute_move);

            public delegate int DLL_OGG_GetChannels(ref DLLSoundReaderOGG.Data data);

            public delegate int DLL_OGG_GetSampleRate(ref DLLSoundReaderOGG.Data data);

            public delegate int DLL_OGG_GetSampleBit(ref DLLSoundReaderOGG.Data data);

            public delegate uint DLL_OGG_GetTotalSampleLengs(ref DLLSoundReaderOGG.Data data);
        }
    }

    public class DLLTJSParamAccess : DLLClass
    {
        public DLLTJSParamAccess.DelegateType.DLL_TJS_ParamAccess_Size Size;
        public DLLTJSParamAccess.DelegateType.DLL_TJS_ParamAccess_At At;
        public DLLTJSParamAccess.DelegateType.DLL_TJS_ParamAccess_GetClassUniqueId GetClassUniqueId;
        public DLLTJSParamAccess.DelegateType.DLL_TJS_ParamAccess_GetNameKey GetNameKey;

        public override void ConnectFunction(BaseDllPack dll)
        {
            this.ConnectSupport<DLLTJSParamAccess.DelegateType.DLL_TJS_ParamAccess_Size>(dll, out this.Size);
            this.ConnectSupport<DLLTJSParamAccess.DelegateType.DLL_TJS_ParamAccess_At>(dll, out this.At);
            this.ConnectSupport<DLLTJSParamAccess.DelegateType.DLL_TJS_ParamAccess_GetClassUniqueId>(dll, out this.GetClassUniqueId);
            this.ConnectSupport<DLLTJSParamAccess.DelegateType.DLL_TJS_ParamAccess_GetNameKey>(dll, out this.GetNameKey);
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct DelegateType
        {
            public delegate int DLL_TJS_ParamAccess_Size(IntPtr ptr);

            public delegate IntPtr DLL_TJS_ParamAccess_At(IntPtr ptr, int num);

            public delegate ulong DLL_TJS_ParamAccess_GetClassUniqueId(IntPtr ptr);

            public delegate ulong DLL_TJS_ParamAccess_GetNameKey(IntPtr ptr);
        }
    }

    public class DLLTJSScript : DLLClass
    {
        public DLLTJSScript.DelegateType.DLL_TJS_CreateTjsScriptClass Create;
        public DLLTJSScript.DelegateType.DLL_TJS_DeleteTjsScriptClass Delete;
        public DLLTJSScript.DelegateType.DLL_TJS_ExecScript ExecScript;
        public DLLTJSScript.DelegateType.DLL_TJS_ExecScriptFile ExecScriptFile;
        public DLLTJSScript.DelegateType.DLL_TJS_EvalScript EvalScript;
        public DLLTJSScript.DelegateType.DLL_TJS_EvalScriptFile EvalScriptFile;
        public DLLTJSScript.DelegateType.DLL_TJS_AddMemberFunction AddMemberFunction;
        public DLLTJSScript.DelegateType.DLL_TJS_GetUniqueID GetUniqueID;

        public override void ConnectFunction(BaseDllPack dll)
        {
            this.ConnectSupport<DLLTJSScript.DelegateType.DLL_TJS_CreateTjsScriptClass>(dll, out this.Create);
            this.ConnectSupport<DLLTJSScript.DelegateType.DLL_TJS_DeleteTjsScriptClass>(dll, out this.Delete);
            this.ConnectSupport<DLLTJSScript.DelegateType.DLL_TJS_ExecScript>(dll, out this.ExecScript);
            this.ConnectSupport<DLLTJSScript.DelegateType.DLL_TJS_ExecScriptFile>(dll, out this.ExecScriptFile);
            this.ConnectSupport<DLLTJSScript.DelegateType.DLL_TJS_EvalScript>(dll, out this.EvalScript);
            this.ConnectSupport<DLLTJSScript.DelegateType.DLL_TJS_EvalScriptFile>(dll, out this.EvalScriptFile);
            this.ConnectSupport<DLLTJSScript.DelegateType.DLL_TJS_AddMemberFunction>(dll, out this.AddMemberFunction);
            this.ConnectSupport<DLLTJSScript.DelegateType.DLL_TJS_GetUniqueID>(dll, out this.GetUniqueID);
        }

        public struct Data
        {
            public IntPtr object_ptr;
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct DelegateType
        {
            public delegate void DLL_TJS_CreateTjsScriptClass(ref DLLFileSystem.Data file_system_data, ref DLLTJSScript.Data data);

            public delegate void DLL_TJS_DeleteTjsScriptClass(ref DLLTJSScript.Data data);

            public delegate void DLL_TJS_ExecScript(ref DLLTJSScript.Data data, [MarshalAs(UnmanagedType.LPStr), In] string exec_str, IntPtr result);

            public delegate int DLL_TJS_ExecScriptFile(ref DLLTJSScript.Data data, ref DLLFile.Data file_data, IntPtr result);

            public delegate float DLL_TJS_EvalScript(ref DLLTJSScript.Data data, [MarshalAs(UnmanagedType.LPStr), In] string eval_str, IntPtr result);

            public delegate int DLL_TJS_EvalScriptFile(ref DLLTJSScript.Data data, ref DLLFile.Data file_data, IntPtr result);

            public delegate ulong DLL_TJS_AddMemberFunction(ref DLLTJSScript.Data data, [MarshalAs(UnmanagedType.LPStr), In] string function_name, DLLTJSScript.FunctionCallBack call_back);

            public delegate ulong DLL_TJS_GetUniqueID(ref DLLTJSScript.Data ptr);
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)]
        public delegate void FunctionCallBack(IntPtr param_access_ptr, IntPtr result);
    }

    public class DLLTJSVariant : DLLClass
    {
        public DLLTJSVariant.DelegateType.DLL_TJSVariant_Create Create;
        public DLLTJSVariant.DelegateType.DLL_TJSVariant_Reference Reference;
        public DLLTJSVariant.DelegateType.DLL_TJSVariant_Delete Delete;
        public DLLTJSVariant.DelegateType.DLL_TJSVariant_Clear Clear;
        public DLLTJSVariant.DelegateType.DLL_TJSVariant_GetType GetTJSType;
        public DLLTJSVariant.DelegateType.DLL_TJSVariant_AsInteger AsInteger;
        public DLLTJSVariant.DelegateType.DLL_TJSVariant_AsReal AsReal;
        public DLLTJSVariant.DelegateType.DLL_TJSVariant_AsString AsString;
        public DLLTJSVariant.DelegateType.DLL_TJSVariant_SetInteger SetInteger;
        public DLLTJSVariant.DelegateType.DLL_TJSVariant_SetReal SetReal;
        public DLLTJSVariant.DelegateType.DLL_TJSVariant_SetString SetString;

        public override void ConnectFunction(BaseDllPack dll)
        {
            this.ConnectSupport<DLLTJSVariant.DelegateType.DLL_TJSVariant_Create>(dll, out this.Create);
            this.ConnectSupport<DLLTJSVariant.DelegateType.DLL_TJSVariant_Reference>(dll, out this.Reference);
            this.ConnectSupport<DLLTJSVariant.DelegateType.DLL_TJSVariant_Clear>(dll, out this.Clear);
            this.ConnectSupport<DLLTJSVariant.DelegateType.DLL_TJSVariant_Delete>(dll, out this.Delete);
            this.ConnectSupport<DLLTJSVariant.DelegateType.DLL_TJSVariant_GetType>(dll, out this.GetTJSType);
            this.ConnectSupport<DLLTJSVariant.DelegateType.DLL_TJSVariant_AsInteger>(dll, out this.AsInteger);
            this.ConnectSupport<DLLTJSVariant.DelegateType.DLL_TJSVariant_AsReal>(dll, out this.AsReal);
            this.ConnectSupport<DLLTJSVariant.DelegateType.DLL_TJSVariant_AsString>(dll, out this.AsString);
            this.ConnectSupport<DLLTJSVariant.DelegateType.DLL_TJSVariant_SetInteger>(dll, out this.SetInteger);
            this.ConnectSupport<DLLTJSVariant.DelegateType.DLL_TJSVariant_SetReal>(dll, out this.SetReal);
            this.ConnectSupport<DLLTJSVariant.DelegateType.DLL_TJSVariant_SetString>(dll, out this.SetString);
        }

        public enum Type
        {
            tvtVoid,
            tvtObject,
            tvtString,
            tvtOctet,
            tvtInteger,
            tvtReal,
        }

        public struct Data
        {
            public IntPtr object_ptr;
        }

        [StructLayout(LayoutKind.Sequential, Size = 1)]
        public struct DelegateType
        {
            public delegate void DLL_TJSVariant_Create(ref DLLTJSVariant.Data data);

            public delegate void DLL_TJSVariant_Reference(ref DLLTJSVariant.Data data, IntPtr ref_ptr);

            public delegate void DLL_TJSVariant_Delete(ref DLLTJSVariant.Data data);

            public delegate void DLL_TJSVariant_Clear(ref DLLTJSVariant.Data data);

            public delegate int DLL_TJSVariant_GetType(ref DLLTJSVariant.Data data);

            public delegate int DLL_TJSVariant_AsInteger(ref DLLTJSVariant.Data data);

            public delegate float DLL_TJSVariant_AsReal(ref DLLTJSVariant.Data data);

            public delegate void DLL_TJSVariant_AsString(ref DLLTJSVariant.Data data, IntPtr dest, int dest_buff_size);

            public delegate void DLL_TJSVariant_SetInteger(ref DLLTJSVariant.Data data, int nums);

            public delegate void DLL_TJSVariant_SetReal(ref DLLTJSVariant.Data data, float nums);

            public delegate void DLL_TJSVariant_SetString(ref DLLTJSVariant.Data data, [MarshalAs(UnmanagedType.LPStr), In] string str);
        }
    }

    public static class StaticDll
    {
        [DllImport("User32.Dll")]
        public static extern IntPtr GetActiveWindow();

        [DllImport("User32.Dll")]
        public static extern void SetWindowText(IntPtr hwnd, string text);

        [DllImport("kernel32", EntryPoint = "LoadLibrary", SetLastError = true)]
        public static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("kernel32", EntryPoint = "GetProcAddress", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32", EntryPoint = "FreeLibrary", SetLastError = true)]
        public static extern bool FreeLibrary(IntPtr hModule);

        [DllImport("device_hook")]
        public static extern IntPtr CreateDeviceData();

        [DllImport("device_hook")]
        public static extern IntPtr CreateTexterFromCompileTexFile(IntPtr file);

        [DllImport("device_hook")]
        public static extern IntPtr CreateTexter(IntPtr file);

        [DllImport("device_hook")]
        public static extern int GetTexterWidthFromLastCreateTexter();

        [DllImport("device_hook")]
        public static extern int GetTexterHeightFromLastCreateTexter();

        [DllImport("device_hook")]
        public static extern void DeleteDeviceData(IntPtr device_data);

        [DllImport("device_hook")]
        public static extern void UnitySetGraphicsDevice(IntPtr device, int deviceType, int eventType);

        [DllImport("device_hook")]
        public static extern IntPtr CreateDesktopDuplication([MarshalAs(UnmanagedType.LPStr)] [In] string device_name);

        [DllImport("device_hook")]
        public static extern void DeleteDesktopDuplication(IntPtr desktop_duplication_class);

        [DllImport("device_hook")]
        public static extern void SetDesktopDuplicationDrawTex(IntPtr desktop_duplication_class, IntPtr texture);

        [DllImport("device_hook")]
        public static extern int GetDesktopDuplicationRenderID(IntPtr desktop_duplication_class);

        [DllImport("device_hook")]
        public static extern IntPtr GetDesktopDuplicationRenderEventFunc();

        [DllImport("device_hook")]
        public static extern int GetDesktopDuplicationRenderWidth(IntPtr desktop_duplication_class);

        [DllImport("device_hook")]
        public static extern int GetDesktopDuplicationRenderHeight(IntPtr desktop_duplication_class);

        [DllImport("device_hook")]
        public static extern int GetDesktopDuplicationIsMousePointerVisible(IntPtr desktop_duplication_class);

        [DllImport("device_hook")]
        public static extern int GetDesktopDuplicationGetMousePointerX(IntPtr desktop_duplication_class);

        [DllImport("device_hook")]
        public static extern int GetDesktopDuplicationGetMousePointerY(IntPtr desktop_duplication_class);

        [DllImport("device_hook")]
        public static extern IntPtr CreateMonitorData();

        [DllImport("device_hook")]
        public static extern void DeleteMonitorData(IntPtr monitor_data);

        [DllImport("device_hook")]
        public static extern int GetMonitorCount(IntPtr monitor_data);

        [DllImport("device_hook")]
        public static extern void GetMonitorName(IntPtr monitor_data, int monitor_no, IntPtr dest, int dest_buff_size);

        [DllImport("device_hook")]
        public static extern int GetMonitorWidth(IntPtr monitor_data, int monitor_no);

        [DllImport("device_hook")]
        public static extern int GetMonitorHeight(IntPtr monitor_data, int monitor_no);

        [DllImport("device_hook")]
        public static extern bool IsMonitorPrimary(IntPtr monitor_data, int monitor_no);
    }

    public abstract class BaseDllPack : IDisposable
    {
        public readonly string kAppDataPath = AppDomain.CurrentDomain.BaseDirectory + @"CM3D2x64_Data\";
        public const string kUseDllPath_x86 = "Plugins/";
        public const string kUseDllPath_x64 = "Plugins/";
        protected IntPtr module_handle_;
        private bool is_disposed_;

        protected abstract string module_name_x86 { get; }

        protected abstract string module_name_x64 { get; }

        public BaseDllPack()
        {
            this.module_handle_ = StaticDll.LoadLibrary(this.kAppDataPath + @"Plugins\" + this.module_name_x86);
            if (this.module_handle_ == IntPtr.Zero)
                this.module_handle_ = StaticDll.LoadLibrary(this.kAppDataPath + "Plugins\\" + this.module_name_x64);
            if (!(this.module_handle_ == IntPtr.Zero))
                return;

            Console.WriteLine(Marshal.GetLastWin32Error());
            //Debug.LogError((object)("loaded dll : " + this.module_name_x86 + " & " + this.module_name_x64));
        }

        ~BaseDllPack()
        {
            this.ExecDispose();
        }

        public void GetProcDelegate<T>(out T dest, string method) where T : class
        {
            IntPtr procAddress = StaticDll.GetProcAddress(this.module_handle_, method);
            Console.WriteLine(Marshal.GetLastWin32Error());
            try
            {
                dest = (object)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(T)) as T;
            }
            catch (Exception e)
            {
                
                Console.WriteLine(e.StackTrace);
                dest = (T)null;
                //Debug.LogError((object)("not found method => " + method));
            }
        }

        public void Dispose()
        {
            this.ExecDispose();
            GC.SuppressFinalize((object)this);
        }

        protected virtual void ExecDispose()
        {
            if (this.is_disposed_)
                return;
            if (this.module_handle_ != IntPtr.Zero)
            {

            }
            this.module_handle_ = IntPtr.Zero;
            this.is_disposed_ = true;
        }
    }

    public class MainDllPack : BaseDllPack
    {
        protected override string module_name_x86
        {
            get
            {
                return "cm3d2_x86.dll";
            }
        }

        protected override string module_name_x64
        {
            get
            {
                return "cm3d2_x64.dll";
            }
        }
    }

    public abstract class DLLClass
    {
        public abstract void ConnectFunction(BaseDllPack dll);

        protected void ConnectSupport<T>(BaseDllPack dll, out T dest) where T : class
        {
            dll.GetProcDelegate<T>(out dest, typeof(T).Name);
            if ((object)dest == null)
                throw new ArgumentNullException();
        }

        public enum ErrorCode
        {
            Failed,
            OK,
            TextureFormatFraud,
        }
    }

    // Token: 0x0200011B RID: 283
    public class Cm3D2Dll : IDisposable
    {
        // Token: 0x0600086C RID: 2156 RVA: 0x00053574 File Offset: 0x00051774
        public Cm3D2Dll()
        {
            //StaticDll.UnitySetGraphicsDevice((IntPtr)0, 0, 0);
            this.dll_list_.Add(this.dll_mgr_);
            foreach (KeyValuePair<DLLClass, Cm3D2Dll.ClassSet.DLLType> keyValuePair in this.function_.object_list)
            {
                DLLClass key = keyValuePair.Key;
                if (keyValuePair.Value == Cm3D2Dll.ClassSet.DLLType.Main)
                {
                    key.ConnectFunction(this.dll_mgr_);
                }
            }
        }

        // Token: 0x0600086D RID: 2157 RVA: 0x00053650 File Offset: 0x00051850
        ~Cm3D2Dll()
        {
            this.Dispose(false);
        }

        // Token: 0x0600086E RID: 2158 RVA: 0x0005368C File Offset: 0x0005188C
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Token: 0x0600086F RID: 2159 RVA: 0x0005369C File Offset: 0x0005189C
        protected virtual void Dispose(bool is_release_managed_code)
        {
            if (this.is_disposed_)
            {
                return;
            }
            if (is_release_managed_code)
            {
                this.function_ = null;
            }
            for (int i = 0; i < this.dll_list_.Count; i++)
            {
                if (this.dll_list_[i] != null)
                {
                    this.dll_list_[i].Dispose();
                }
                this.dll_list_[i] = null;
            }
            this.dll_list_.Clear();
            this.is_disposed_ = true;
        }

        // Token: 0x170000CC RID: 204
        // (get) Token: 0x06000870 RID: 2160 RVA: 0x00053720 File Offset: 0x00051920
        public Cm3D2Dll.ClassSet call
        {
            get
            {
                return (this.dll_list_.Count == 0) ? null : this.function_;
            }
        }

        // Token: 0x040007DB RID: 2011
        public const int kBuffSize = 8192;

        // Token: 0x040007DC RID: 2012
        public byte[] tmp_buff = new byte[8192];

        // Token: 0x040007DD RID: 2013
        private Cm3D2Dll.ClassSet function_ = new Cm3D2Dll.ClassSet();

        // Token: 0x040007DE RID: 2014
        private bool is_disposed_;

        // Token: 0x040007DF RID: 2015
        private List<BaseDllPack> dll_list_ = new List<BaseDllPack>();

        // Token: 0x040007E0 RID: 2016
        private MainDllPack dll_mgr_ = new MainDllPack();

        // Token: 0x0200011C RID: 284
        public class ClassSet
        {
            // Token: 0x06000871 RID: 2161 RVA: 0x00053740 File Offset: 0x00051940
            public ClassSet()
            {
                this.Create<DLLFileSystem>(ref this.file_system_, Cm3D2Dll.ClassSet.DLLType.Main);
                this.Create<DLLFile>(ref this.file_, Cm3D2Dll.ClassSet.DLLType.Main);
                this.Create<DLLColorPalette>(ref this.color_palette_, Cm3D2Dll.ClassSet.DLLType.Main);
                this.Create<DLLCsvParser>(ref this.csv_parser_, Cm3D2Dll.ClassSet.DLLType.Main);
                this.Create<DLLTJSVariant>(ref this.tjs_variant_, Cm3D2Dll.ClassSet.DLLType.Main);
                this.Create<DLLTJSScript>(ref this.tjs_script_, Cm3D2Dll.ClassSet.DLLType.Main);
                this.Create<DLLTJSParamAccess>(ref this.tjs_param_access_, Cm3D2Dll.ClassSet.DLLType.Main);
                this.Create<DLLKagTagSupport>(ref this.kag_tag_support_, Cm3D2Dll.ClassSet.DLLType.Main);
                this.Create<DLLKagScript>(ref this.kag_script_, Cm3D2Dll.ClassSet.DLLType.Main);
                this.Create<DLLSoundReaderOGG>(ref this.sound_reader_ogg_, Cm3D2Dll.ClassSet.DLLType.Main);
                this.Create<DLLNativeArray>(ref this.native_array_, Cm3D2Dll.ClassSet.DLLType.Main);
                this.Create<DLLPluginData>(ref this.plugin_data_, Cm3D2Dll.ClassSet.DLLType.Main);
                this.Create<DLLAnmParse>(ref this.anm_parse_, Cm3D2Dll.ClassSet.DLLType.Main);
                this.Create<DLLMenuParse>(ref this.menu_parse_, Cm3D2Dll.ClassSet.DLLType.Main);
            }

            // Token: 0x06000872 RID: 2162 RVA: 0x00053814 File Offset: 0x00051A14
            private void Create<Type>(ref Type dest, Cm3D2Dll.ClassSet.DLLType dll_type) where Type : DLLClass, new()
            {
                dest = Activator.CreateInstance<Type>();
                this.object_list.Add(new KeyValuePair<DLLClass, Cm3D2Dll.ClassSet.DLLType>(dest, dll_type));
            }

            // Token: 0x170000CD RID: 205
            // (get) Token: 0x06000873 RID: 2163 RVA: 0x00053840 File Offset: 0x00051A40
            public DLLFileSystem file_system
            {
                get
                {
                    return this.file_system_;
                }
            }

            // Token: 0x170000CE RID: 206
            // (get) Token: 0x06000874 RID: 2164 RVA: 0x00053848 File Offset: 0x00051A48
            public DLLFile file
            {
                get
                {
                    return this.file_;
                }
            }

            // Token: 0x170000CF RID: 207
            // (get) Token: 0x06000875 RID: 2165 RVA: 0x00053850 File Offset: 0x00051A50
            public DLLColorPalette color_palette
            {
                get
                {
                    return this.color_palette_;
                }
            }

            // Token: 0x170000D0 RID: 208
            // (get) Token: 0x06000876 RID: 2166 RVA: 0x00053858 File Offset: 0x00051A58
            public DLLCsvParser csv_parser
            {
                get
                {
                    return this.csv_parser_;
                }
            }

            // Token: 0x170000D1 RID: 209
            // (get) Token: 0x06000877 RID: 2167 RVA: 0x00053860 File Offset: 0x00051A60
            public DLLTJSVariant tjs_variant
            {
                get
                {
                    return this.tjs_variant_;
                }
            }

            // Token: 0x170000D2 RID: 210
            // (get) Token: 0x06000878 RID: 2168 RVA: 0x00053868 File Offset: 0x00051A68
            public DLLTJSScript tjs_script
            {
                get
                {
                    return this.tjs_script_;
                }
            }

            // Token: 0x170000D3 RID: 211
            // (get) Token: 0x06000879 RID: 2169 RVA: 0x00053870 File Offset: 0x00051A70
            public DLLTJSParamAccess tjs_param_access
            {
                get
                {
                    return this.tjs_param_access_;
                }
            }

            // Token: 0x170000D4 RID: 212
            // (get) Token: 0x0600087A RID: 2170 RVA: 0x00053878 File Offset: 0x00051A78
            public DLLKagTagSupport kag_tag_support
            {
                get
                {
                    return this.kag_tag_support_;
                }
            }

            // Token: 0x170000D5 RID: 213
            // (get) Token: 0x0600087B RID: 2171 RVA: 0x00053880 File Offset: 0x00051A80
            public DLLKagScript kag_script
            {
                get
                {
                    return this.kag_script_;
                }
            }

            // Token: 0x170000D6 RID: 214
            // (get) Token: 0x0600087C RID: 2172 RVA: 0x00053888 File Offset: 0x00051A88
            public DLLSoundReaderOGG sound_reader_ogg
            {
                get
                {
                    return this.sound_reader_ogg_;
                }
            }

            // Token: 0x170000D7 RID: 215
            // (get) Token: 0x0600087D RID: 2173 RVA: 0x00053890 File Offset: 0x00051A90
            public DLLNativeArray native_array
            {
                get
                {
                    return this.native_array_;
                }
            }

            // Token: 0x170000D8 RID: 216
            // (get) Token: 0x0600087E RID: 2174 RVA: 0x00053898 File Offset: 0x00051A98
            public DLLPluginData plugin_data
            {
                get
                {
                    return this.plugin_data_;
                }
            }

            // Token: 0x170000D9 RID: 217
            // (get) Token: 0x0600087F RID: 2175 RVA: 0x000538A0 File Offset: 0x00051AA0
            public DLLAnmParse anm_parse
            {
                get
                {
                    return this.anm_parse_;
                }
            }

            // Token: 0x170000DA RID: 218
            // (get) Token: 0x06000880 RID: 2176 RVA: 0x000538A8 File Offset: 0x00051AA8
            public DLLMenuParse menu_parse
            {
                get
                {
                    return this.menu_parse_;
                }
            }

            // Token: 0x040007E1 RID: 2017
            public List<KeyValuePair<DLLClass, Cm3D2Dll.ClassSet.DLLType>> object_list = new List<KeyValuePair<DLLClass, Cm3D2Dll.ClassSet.DLLType>>();

            // Token: 0x040007E2 RID: 2018
            private DLLFileSystem file_system_;

            // Token: 0x040007E3 RID: 2019
            private DLLFile file_;

            // Token: 0x040007E4 RID: 2020
            private DLLColorPalette color_palette_;

            // Token: 0x040007E5 RID: 2021
            private DLLCsvParser csv_parser_;

            // Token: 0x040007E6 RID: 2022
            private DLLTJSVariant tjs_variant_;

            // Token: 0x040007E7 RID: 2023
            private DLLTJSScript tjs_script_;

            // Token: 0x040007E8 RID: 2024
            private DLLTJSParamAccess tjs_param_access_;

            // Token: 0x040007E9 RID: 2025
            private DLLKagTagSupport kag_tag_support_;

            // Token: 0x040007EA RID: 2026
            private DLLKagScript kag_script_;

            // Token: 0x040007EB RID: 2027
            private DLLSoundReaderOGG sound_reader_ogg_;

            // Token: 0x040007EC RID: 2028
            private DLLNativeArray native_array_;

            // Token: 0x040007ED RID: 2029
            private DLLPluginData plugin_data_;

            // Token: 0x040007EE RID: 2030
            private DLLAnmParse anm_parse_;

            // Token: 0x040007EF RID: 2031
            private DLLMenuParse menu_parse_;

            // Token: 0x0200011D RID: 285
            public enum DLLType
            {
                // Token: 0x040007F1 RID: 2033
                Main
            }
        }
    }

// Token: 0x02000120 RID: 288
public class DLLManager
    {
        // Token: 0x170000DB RID: 219
        // (get) Token: 0x06000885 RID: 2181 RVA: 0x000538FC File Offset: 0x00051AFC
        public static Cm3D2Dll cm3d2dll
        {
            get
            {
                return DLLManager.dll_;
            }
        }

        // Token: 0x06000886 RID: 2182 RVA: 0x00053904 File Offset: 0x00051B04
        public static void Initialize()
        {
            DLLManager.dll_ = new Cm3D2Dll();
        }

        // Token: 0x06000887 RID: 2183 RVA: 0x00053910 File Offset: 0x00051B10
        public static void Finalizer()
        {
            DLLManager.dll_.Dispose();
            DLLManager.dll_ = null;
        }

        // Token: 0x040007F6 RID: 2038
        private static Cm3D2Dll dll_;
    }

// Token: 0x02000153 RID: 339
public class FileSystemArchive : AFileSystemBase
    {
        // Token: 0x060008D9 RID: 2265 RVA: 0x0005496C File Offset: 0x00052B6C
        public FileSystemArchive()
        {
            this.dll_ = DLLManager.cm3d2dll;
            if (this.dll_ == null)
            {
                throw new ArgumentNullException();
            }
            this.dll_.call.file_system.CreateArchiveSystem(ref this.file_system_);
        }

        // Token: 0x060008DA RID: 2266 RVA: 0x000549CC File Offset: 0x00052BCC
        public override bool IsValid()
        {
            return this.dll_.call.file_system.IsValid(ref this.file_system_);
        }

        // Token: 0x060008DB RID: 2267 RVA: 0x000549FC File Offset: 0x00052BFC
        public override void AddAutoPathForAllFolder()
        {
            this.dll_.call.file_system.AddAutoPathForAllFolder(ref this.file_system_);
        }

        // Token: 0x060008DC RID: 2268 RVA: 0x00054A2C File Offset: 0x00052C2C
        public unsafe override string[] GetList(string f_str_path, AFileSystemBase.ListType type)
        {
            DLLFileSystem.ListData listData = default(DLLFileSystem.ListData);
            this.dll_.call.file_system.CreateList(ref this.file_system_, f_str_path, type, ref listData);
            string[] array = new string[listData.size];
            byte[] empty = new byte[0];
            fixed (byte* value = (this.dll_.tmp_buff != null && this.dll_.tmp_buff.Length != 0) ? this.dll_.tmp_buff : empty)
		    {
                for (int i = 0; i < listData.size; i++)
                {
                    int count = this.dll_.call.file_system.AtList(ref listData, i, (IntPtr)((void*)value), this.dll_.tmp_buff.Length);
                    array[i] = Encoding.UTF8.GetString(this.dll_.tmp_buff, 0, count);
                }
            }
            this.dll_.call.file_system.DeleteList(ref listData);
            return array;
        }

        // Token: 0x060008DD RID: 2269 RVA: 0x00054B34 File Offset: 0x00052D34
        public bool AddArchive(string path)
        {
            return this.dll_.call.file_system.AddArchive(ref this.file_system_, path);
        }

        // Token: 0x060008DE RID: 2270 RVA: 0x00054B58 File Offset: 0x00052D58
        public bool AddAutoPath(string path)
        {
            return this.dll_.call.file_system.AddAutoPath(ref this.file_system_, path);
        }

        // Token: 0x060008DF RID: 2271 RVA: 0x00054B7C File Offset: 0x00052D7C
        public bool SetBaseDirectory(string path)
        {
            return this.dll_.call.file_system.SetBaseDirectory(ref this.file_system_, path);
        }

        // Token: 0x060008E0 RID: 2272 RVA: 0x00054BA0 File Offset: 0x00052DA0
        public override AFileBase FileOpen(string file_name)
        {
            DLLFile.Data file_data = default(DLLFile.Data);
            this.dll_.call.file_system.GetFile(ref this.file_system_, file_name, ref file_data);
            if (file_data.object_pointer == IntPtr.Zero)
            {
                return new FileWfNull();
            }
            return new WfFile(file_data);
        }

        // Token: 0x060008E1 RID: 2273 RVA: 0x00054BFC File Offset: 0x00052DFC
        public override bool IsExistentFile(string file_name)
        {
            return this.dll_.call.file_system.IsExistentFile(ref this.file_system_, file_name);
        }

        // Token: 0x060008E2 RID: 2274 RVA: 0x00054C20 File Offset: 0x00052E20
        protected override void Dispose(bool is_release_managed_code)
        {
            try
            {
                if (this.is_disposed_)
                {
                    return;
                }
                this.dll_.call.file_system.DeleteFileSystem(ref this.file_system_);
                this.dll_ = null;
                this.is_disposed_ = true;
            } catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        // Token: 0x170000E1 RID: 225
        // (get) Token: 0x060008E3 RID: 2275 RVA: 0x00054C68 File Offset: 0x00052E68
        public override DLLFileSystem.Data object_data
        {
            get
            {
                return this.file_system_;
            }
        }

        // Token: 0x040008D2 RID: 2258
        private Cm3D2Dll dll_;

        // Token: 0x040008D3 RID: 2259
        private DLLFileSystem.Data file_system_ = default(DLLFileSystem.Data);
    }

// Token: 0x0200031B RID: 795
public class GameUty
    {
        // Token: 0x060016E5 RID: 5861 RVA: 0x000113A4 File Offset: 0x0000F5A4
        public static bool CheckPackFlag(PluginData.Type type)
        {
            return GameUty.m_PluginData.IsEnabled(type);
        }

        // Token: 0x170002E9 RID: 745
        // (get) Token: 0x060016E6 RID: 5862 RVA: 0x000113B1 File Offset: 0x0000F5B1
        public static AFileSystemBase FileSystem
        {
            get
            {
                return GameUty.m_FileSystem;
            }
        }

        // Token: 0x170002EA RID: 746
        // (get) Token: 0x060016E7 RID: 5863 RVA: 0x000113B8 File Offset: 0x0000F5B8
        public static AFileSystemBase FileSystemMod
        {
            get
            {
                return GameUty.m_ModFileSystem;
            }
        }

        // Token: 0x170002EB RID: 747
        // (get) Token: 0x060016E8 RID: 5864 RVA: 0x000113BF File Offset: 0x0000F5BF
        public static string[] MenuFiles
        {
            get
            {
                return GameUty.m_aryMenuFiles;
            }
        }

        // Token: 0x170002EC RID: 748
        // (get) Token: 0x060016E9 RID: 5865 RVA: 0x000113C6 File Offset: 0x0000F5C6
        public static Dictionary<int, string> RidMenuDic
        {
            get
            {
                return GameUty.rid_menu_dic_;
            }
        }

        // Token: 0x170002ED RID: 749
        // (get) Token: 0x060016EA RID: 5866 RVA: 0x000113CD File Offset: 0x0000F5CD
        public static string[] BgFiles
        {
            get
            {
                return GameUty.m_aryBgFiles;
            }
        }

        // Token: 0x060016EB RID: 5867 RVA: 0x000113D4 File Offset: 0x0000F5D4
        public static float MillisecondToSecond(int millisecond)
        {
            return (float)millisecond / 1000f;
        }

        // Token: 0x060016EE RID: 5870 RVA: 0x000AD6B0 File Offset: 0x000AB8B0
        public static void Init()
        {
            GameUty.m_FileSystem = new FileSystemArchive();
            GameUty.UpdateFileSystemPath();
            Action<PluginData.Type> action = delegate (PluginData.Type check_type)
            {
                Debug.Log(check_type.ToString() + " : " + ((!GameUty.m_PluginData.IsEnabled(check_type)) ? "×" : "○"));
            };
            GameUty.m_PluginData = new PluginData(GameUty.m_FileSystem);
            foreach (object obj in Enum.GetValues(typeof(PluginData.Type)))
            {
                PluginData.Type type = (PluginData.Type)((int)obj);
                if (type != PluginData.Type.NON)
                {
                    action(type);
                }
            }
        }

        // Token: 0x060016EF RID: 5871 RVA: 0x000AD760 File Offset: 0x000AB960
        public static void Finish()
        {
            GameUty.m_PluginData.Dispose();
            GameUty.m_PluginData = null;
            GameUty.m_FileSystem.Dispose();
            GameUty.m_FileSystem = null;
            if (GameUty.m_ModFileSystem != null)
            {
                GameUty.m_ModFileSystem.Dispose();
                GameUty.m_ModFileSystem = null;
            }
        }

        // Token: 0x060016F0 RID: 5872 RVA: 0x000AD804 File Offset: 0x000ABA04
        public static Dictionary<string, HashSet<string>> GetGameDataResourceList(string gameDataPath)
        {
            string[] array = new string[]
            {
            "script_cbl",
            "motion_cbl",
            "voice_cbl"
            };
            int length = (gameDataPath + "\\").Length;
            string[] directories = Directory.GetDirectories(gameDataPath);
            Dictionary<string, HashSet<string>> dictionary = new Dictionary<string, HashSet<string>>();
            for (int i = 0; i < directories.Length; i++)
            {
                string text = directories[i].Substring(length, directories[i].Length - length).ToLower();
                int startIndex = 0;
                foreach (string text2 in array)
                {
                    if (text.IndexOf(text2) == 0)
                    {
                        startIndex = text2.Length;
                        break;
                    }
                }
                int num = text.IndexOf('_', startIndex);
                if (0 <= num)
                {
                    string text3 = text.Substring(0, num);
                    if (!string.IsNullOrEmpty(text3))
                    {
                        string text4 = text.Substring(text3.Length + 1, text.Length - (text3.Length + 1));
                        if (!string.IsNullOrEmpty(text4))
                        {
                            if (!dictionary.ContainsKey(text3))
                            {
                                dictionary.Add(text3, new HashSet<string>());
                            }
                            if (!dictionary[text3].Contains(text4))
                            {
                                dictionary[text3].Add(text4);
                            }
                            else
                            {
                                Debug.LogWarning(text3 + "_" + text4 + "は既にリストに存在します");
                            }
                        }
                    }
                }
                else if (!dictionary.ContainsKey(text))
                {
                    dictionary.Add(text, new HashSet<string>());
                }
                else
                {
                    Debug.LogWarning(text + "は既にリストに存在します");
                }
            }
            return dictionary;
        }

        // Token: 0x060016F1 RID: 5873 RVA: 0x000AD9BC File Offset: 0x000ABBBC
        public static void UpdateFileSystemPath()
        {
            string fullPath = Path.GetFullPath(".\\");
            GameUty.m_FileSystem.SetBaseDirectory(fullPath);
            string path = fullPath + "GameData\\paths.dat";
            List<string> list = new List<string>();
            if (File.Exists(path))
            {
                FileStream fileStream = new FileStream(path, FileMode.Open);
                if (fileStream != null)
                {
                    BinaryReader binaryReader = new BinaryReader(fileStream);
                    string a = binaryReader.ReadString();
                    int num = binaryReader.ReadInt32();
                    int num2 = binaryReader.ReadInt32();
                    for (int i2 = 0; i2 < num2; i2++)
                    {
                        string item = binaryReader.ReadString();
                        list.Add(item);
                    }
                    fileStream.Close();
                    fileStream.Dispose();
                }
            }
            GameUty.PathList.Clear();
            for (int j = 0; j < list.Count; j++)
            {
                GameUty.PathList.Add(list[j]);
            }
            int num3 = 3;
            Func<string, bool> func = delegate (string name)
            {
                bool flag = GameUty.m_FileSystem.AddArchive("GameData\\" + name + ".arc");
                if (flag)
                {
                    System.Diagnostics.Debug.WriteLine("readed: " + name);
                    Debug.Log("");
                }
                return flag;
            };
            
            foreach(string arcPath in Directory.GetFiles("GameData", "*.arc", SearchOption.AllDirectories))
            {
                func( Path.GetFileNameWithoutExtension(arcPath) );
            }

            string str = string.Empty;
            str = "必用アーカイブがありません。GameData\\";
            Debug.Log("■■■■■■■■ Archive Log ■■■■■■■■");
            foreach (string text in list)
            {
                string text2 = "csv";
                if (func(text2 + "_" + text))
                {
                    for (int k = 2; k <= num3; k++)
                    {
                        func(string.Concat(new object[]
                        {
                        text2,
                        "_",
                        text,
                        "_",
                        k
                        }));
                    }
                }
            }
            foreach (string text3 in list)
            {
                string text4 = "material";
                if (text3 == "denkigai2015wTowelR")
                {
                    func(text4 + "_denkigai2015wTowel");
                }
                if (func(text4 + "_" + text3))
                {
                    for (int l = 2; l <= num3; l++)
                    {
                        func(string.Concat(new object[]
                        {
                        text4,
                        "_",
                        text3,
                        "_",
                        l
                        }));
                    }
                }
            }
            func("material2");
            func("prioritymaterial");
            foreach (string text5 in list)
            {
                string text6 = "menu";
                if (func(text6 + "_" + text5))
                {
                    for (int m = 2; m <= num3; m++)
                    {
                        func(string.Concat(new object[]
                        {
                        text6,
                        "_",
                        text5,
                        "_",
                        m
                        }));
                    }
                }
            }
            func("menu2");
            foreach (string text7 in list)
            {
                string text8 = "model";
                if (func(text8 + "_" + text7))
                {
                    for (int n = 2; n <= num3; n++)
                    {
                        func(string.Concat(new object[]
                        {
                        text8,
                        "_",
                        text7,
                        "_",
                        n
                        }));
                    }
                }
            }
            func("model2");
            foreach (string text9 in list)
            {
                string text10 = "motion";
                if (func(text10 + "_" + text9))
                {
                    for (int num4 = 2; num4 <= num3; num4++)
                    {
                        func(string.Concat(new object[]
                        {
                        text10,
                        "_",
                        text9,
                        "_",
                        num4
                        }));
                    }
                }
            }
            func("motion2");
            foreach (string text11 in list)
            {
                string text12 = "script";
                if (func(text12 + "_" + text11))
                {
                    for (int num5 = 2; num5 <= num3; num5++)
                    {
                        func(string.Concat(new object[]
                        {
                        text12,
                        "_",
                        text11,
                        "_",
                        num5
                        }));
                    }
                }
            }
            foreach (string text13 in list)
            {
                string text14 = "script_share";
                if (func(text14 + "_" + text13))
                {
                    for (int num6 = 2; num6 <= num3; num6++)
                    {
                        func(string.Concat(new object[]
                        {
                        text14,
                        "_",
                        text13,
                        "_",
                        num6
                        }));
                    }
                }
            }
            func("script_share2");
            foreach (string text15 in list)
            {
                string text16 = "sound";
                if (func(text16 + "_" + text15))
                {
                    for (int num7 = 2; num7 <= num3; num7++)
                    {
                        func(string.Concat(new object[]
                        {
                        text16,
                        "_",
                        text15,
                        "_",
                        num7
                        }));
                    }
                }
            }
            func("sound2");
            foreach (string text17 in list)
            {
                string text18 = "texture";
                if (func(text18 + "_" + text17))
                {
                    for (int num8 = 2; num8 <= num3; num8++)
                    {
                        func(string.Concat(new object[]
                        {
                        text18,
                        "_",
                        text17,
                        "_",
                        num8
                        }));
                    }
                }
            }
            func("texture2");
            func("texture3");
            foreach (string text19 in list)
            {
                string text20 = "system";
                if (func(text20 + "_" + text19))
                {
                    for (int num9 = 2; num9 <= num3; num9++)
                    {
                        func(string.Concat(new object[]
                        {
                        text20,
                        "_",
                        text19,
                        "_",
                        num9
                        }));
                    }
                }
            }
            foreach (string text21 in list)
            {
                string text22 = "bg";
                if (func(text22 + "_" + text21))
                {
                    for (int num10 = 2; num10 <= num3; num10++)
                    {
                        func(string.Concat(new object[]
                        {
                        text22,
                        "_",
                        text21,
                        "_",
                        num10
                        }));
                    }
                }
            }
            foreach (string str2 in list)
            {
                string str3 = "voice";
                string text23 = str3 + "_" + str2;
                if (func(text23))
                {
                    for (int num11 = 2; num11 <= num3; num11++)
                    {
                        func(text23 + "_" + num11);
                    }
                }
                text23 = str3 + "_" + str2 + "a";
                if (func(text23))
                {
                    for (int num12 = 2; num12 <= num3; num12++)
                    {
                        func(text23 + "_" + num12);
                    }
                }
                text23 = str3 + "_" + str2 + "b";
                if (func(text23))
                {
                    for (int num13 = 2; num13 <= num3; num13++)
                    {
                        func(text23 + "_" + num13);
                    }
                }
            }
            func("voice2");
            func("voice3");
            //Debug.Log("■■■■■■■■■■■■■■■■■■■■" + global::wf::stopWatch.Stop().ToString() + " ms");
            GameUty.m_FileSystem.AddAutoPathForAllFolder();
            GameUty.m_aryBgFiles = GameUty.m_FileSystem.GetList("bg", AFileSystemBase.ListType.AllFile);
            if (GameUty.m_aryBgFiles != null && 0 < GameUty.m_aryBgFiles.Length)
            {
                for (int num14 = 0; num14 < GameUty.m_aryBgFiles.Length; num14++)
                {
                    if (Path.GetExtension(GameUty.m_aryBgFiles[num14]) != ".asset_bg")
                    {
                        GameUty.m_aryBgFiles[num14] = string.Empty;
                    }
                }
                List<string> list2 = new List<string>();
                for (int num15 = 0; num15 < GameUty.m_aryBgFiles.Length; num15++)
                {
                    if (!string.IsNullOrEmpty(GameUty.m_aryBgFiles[num15]))
                    {
                        list2.Add(GameUty.m_aryBgFiles[num15]);
                    }
                }
                GameUty.m_aryBgFiles = list2.ToArray();
            }
            if (Directory.Exists(fullPath + "Mod"))
            {
                GameUty.m_ModFileSystem = new FileSystemWindows();
                GameUty.m_ModFileSystem.SetBaseDirectory(fullPath);
                GameUty.m_ModFileSystem.AddFolder("Mod");
                string[] list3 = GameUty.m_ModFileSystem.GetList(string.Empty, AFileSystemBase.ListType.AllFolder);
                foreach (string text24 in list3)
                {
                    if (!GameUty.m_ModFileSystem.AddAutoPath(text24))
                    {
                        Debug.Log("m_ModFileSystemのAddAutoPathには既に " + text24 + " がありました。");
                    }
                }
            }
            GameUty.m_aryMenuFiles = GameUty.m_FileSystem.GetList("menu", AFileSystemBase.ListType.AllFile);
            if (GameUty.m_ModFileSystem != null)
            {
                string[] list4 = GameUty.m_ModFileSystem.GetList(string.Empty, AFileSystemBase.ListType.AllFile);
                string[] second = Array.FindAll<string>(list4, (string i) => new Regex(".*\\.menu").IsMatch(i));
                GameUty.m_aryMenuFiles = GameUty.m_aryMenuFiles.Concat(second).ToArray<string>();
            }
            if (GameUty.m_ModFileSystem != null)
            {
                GameUty.ModPriorityToModFolderInfo = string.Empty;
                Debug.Log(GameUty.ModPriorityToModFolderInfo + "■MOD有り。MODフォルダ優先モード" + GameUty.ModPriorityToModFolder.ToString());
            }
            if (GameUty.rid_menu_dic_.Count == 0)
            {
                string[] menuFiles = GameUty.MenuFiles;
                GameUty.rid_menu_dic_ = new Dictionary<int, string>();
                for (int num17 = 0; num17 < menuFiles.Length; num17++)
                {
                    string fileName = Path.GetFileName(menuFiles[num17]);
                    int hashCode = fileName.ToLower().GetHashCode();
                    if (!GameUty.rid_menu_dic_.ContainsKey(hashCode))
                    {
                        GameUty.rid_menu_dic_.Add(hashCode, fileName);
                    }
                    else
                    {

                    }
                }
            }
        }

        // Token: 0x060016F2 RID: 5874 RVA: 0x000AE984 File Offset: 0x000ACB84
        public static AFileBase FileOpen(string f_strFileName)
        {
            AFileBase result = null;
            if (!GameUty.ModPriorityToModFolder)
            {
                if (GameUty.m_FileSystem.IsExistentFile(f_strFileName))
                {
                    result = GameUty.m_FileSystem.FileOpen(f_strFileName);
                }
                else if (GameUty.m_ModFileSystem != null)
                {
                    result = GameUty.m_ModFileSystem.FileOpen(f_strFileName);
                }
            }
            else if (GameUty.m_ModFileSystem != null && GameUty.m_ModFileSystem.IsExistentFile(f_strFileName))
            {
                result = GameUty.m_ModFileSystem.FileOpen(f_strFileName);
            }
            else if (GameUty.m_FileSystem.IsExistentFile(f_strFileName))
            {
                result = GameUty.m_FileSystem.FileOpen(f_strFileName);
            }
            return result;
        }

        // Token: 0x040012E8 RID: 4840
        private static PluginData m_PluginData = null;

        // Token: 0x040012E9 RID: 4841
        private static FileSystemArchive m_FileSystem = null;

        // Token: 0x040012EA RID: 4842
        private static FileSystemWindows m_ModFileSystem = null;

        // Token: 0x040012EB RID: 4843
        public static List<string> PathList = new List<string>();

        // Token: 0x040012EC RID: 4844
        public static string[] m_aryMenuFiles = null;

        // Token: 0x040012ED RID: 4845
        private static Dictionary<int, string> rid_menu_dic_ = new Dictionary<int, string>();

        // Token: 0x040012EE RID: 4846
        public static string[] m_aryBgFiles = null;

        // Token: 0x040012EF RID: 4847
        //private static Dictionary<string, AssetBundle> asset_bundle_dic = new Dictionary<string, AssetBundle>();

        // Token: 0x040012F0 RID: 4848
        private static string ModPriorityToModFolderInfo = "以下のフラグをtrueにするとMODフォルダのファイルが優先されるが、モザイクも安易に外すことが可能になる為に現在はオミット。";

        // Token: 0x040012F1 RID: 4849
        public static bool ModPriorityToModFolder = false;

        // Token: 0x040012F2 RID: 4850
        private static string[] m_strSystemMaterialName = new string[]
        {
        "System/Material/2dAlpha",
        "System/Material/2dMultiply",
        "System/Material/InfinityColor",
        "System/Material/TexTo8bitTex"
        };

        // Token: 0x040012F3 RID: 4851
        //private static Material[] m_matSystem = new Material[4];

        // Token: 0x0200031C RID: 796
        public enum SystemMaterial
        {
            // Token: 0x040012F8 RID: 4856
            Alpha,
            // Token: 0x040012F9 RID: 4857
            Multiply,
            // Token: 0x040012FA RID: 4858
            InfinityColor,
            // Token: 0x040012FB RID: 4859
            TexTo8bitTex,
            // Token: 0x040012FC RID: 4860
            Max
        }
    }


}
