﻿using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[ExecuteInEditMode]
public class TextShader : ImageEffectBase
{
    #region Field

    // NOTE:
    // Base texture is here(CC0).
    // SpriteFontTextureData is made from "Texture2D.EncodeToPNG()".
    // https://commons.wikimedia.org/wiki/File:Atari_ST_character_set_8x8.png

    protected static          Texture2D  SpriteFontTexture;
    protected static readonly Vector2Int SpriteFontTextureSize = new Vector2Int(128, 48);
    protected static readonly byte[]     SpriteFontTextureData = new byte[]
    {
        137,80,78,71,13,10,26,10,0,0,0,13,73,72,68,82,0,0,0,128,0,0,0,48,8,6,0,0,0,217,244,114,190,0,0,7,191,73,68,65,84,120,1,237,152,137,82,35,73,12,
        68,135,141,249,255,95,102,201,134,215,145,164,85,87,31,30,152,161,34,76,73,202,67,170,114,135,13,188,188,190,190,254,90,88,144,95,66,147,245,204,131,222,76,143,234,100,136,86,113,
        206,167,154,22,156,22,238,28,197,240,208,121,77,241,119,94,58,211,203,127,79,58,129,154,113,137,30,123,123,112,213,146,51,147,75,87,189,97,170,207,46,159,1,47,105,61,118,14,190,
        163,249,90,60,234,207,222,247,51,60,227,1,216,155,189,157,114,20,235,162,253,85,93,12,30,254,166,16,87,88,229,49,170,225,231,188,170,6,14,166,254,87,205,128,247,213,251,167,249,
        94,46,250,10,24,13,233,77,61,118,29,117,106,92,42,185,118,56,137,81,23,39,49,213,102,23,62,45,143,10,167,214,234,33,175,22,167,213,39,189,206,234,241,195,103,239,251,27,228,
        11,236,251,80,111,179,104,80,189,178,166,49,189,166,220,15,133,78,117,173,228,190,87,175,253,73,15,230,192,157,186,114,98,56,228,112,71,251,42,191,242,43,123,175,126,5,104,144,213,
        97,104,172,161,122,177,48,94,226,122,31,116,212,156,39,46,11,92,185,199,224,179,59,253,156,95,213,192,193,212,147,190,212,224,140,118,241,87,53,233,217,242,192,151,217,118,221,234,3,
        208,106,176,27,22,129,55,237,197,45,12,75,199,169,105,167,206,108,158,59,111,38,70,43,46,151,150,177,115,240,84,205,235,153,183,120,212,159,177,251,124,123,191,213,223,1,118,225,79,
        112,233,13,240,176,149,111,210,165,157,194,204,127,7,96,8,40,213,48,112,122,88,165,71,7,198,222,243,113,108,70,159,156,43,245,154,183,231,207,121,142,238,62,171,247,202,122,203,159,
        217,122,124,56,120,108,92,62,1,0,49,200,220,135,82,12,15,179,228,103,14,79,251,12,38,158,247,232,105,70,158,194,115,165,223,217,28,255,244,161,206,62,194,197,155,225,224,231,123,
        79,151,216,158,251,39,0,102,128,228,236,122,67,122,24,188,222,142,222,223,92,248,96,228,213,238,156,202,163,210,100,13,143,163,250,244,187,50,111,205,70,61,123,249,25,20,139,167,151,
        215,165,201,92,181,109,229,39,128,138,24,17,111,196,143,31,12,210,52,124,227,141,56,21,238,53,143,189,183,199,201,33,119,78,53,35,188,30,134,71,114,208,130,107,79,142,99,171,49,
        254,103,61,71,62,159,240,252,43,224,238,230,126,105,12,226,23,229,53,143,157,211,139,53,63,103,72,61,57,184,251,56,6,78,13,30,222,224,212,125,151,38,117,179,56,190,61,189,123,
        85,49,90,188,146,243,128,87,95,1,41,154,205,31,204,77,216,195,68,243,129,43,110,85,51,251,167,134,119,206,162,123,144,191,94,213,157,228,65,43,142,215,122,252,13,227,43,64,9,
        7,67,228,70,137,37,103,132,143,252,241,115,158,247,247,58,220,163,120,234,240,203,51,36,207,241,196,240,232,237,232,103,180,43,92,245,156,229,63,240,252,1,232,13,255,131,253,165,55,
        224,95,1,60,29,28,181,122,82,225,36,70,29,173,246,17,199,241,212,59,38,175,196,85,211,130,55,194,197,173,56,169,111,229,149,30,174,176,92,244,130,179,154,187,95,106,133,101,109,
        148,187,6,239,109,54,126,9,116,131,28,26,1,156,202,12,142,180,149,30,109,11,119,253,140,191,251,160,213,78,157,29,44,251,39,14,175,183,75,195,242,152,218,236,238,179,204,106,196,
        67,199,94,105,91,24,117,63,247,86,227,1,112,51,200,85,237,193,192,73,11,177,251,164,140,203,173,230,72,238,119,203,57,19,103,92,157,31,125,79,55,195,217,245,254,21,176,23,223,
        2,13,184,100,244,33,118,205,209,67,250,28,25,143,252,71,184,252,122,28,199,178,247,85,249,209,123,225,61,97,191,100,158,214,3,208,186,136,86,157,97,56,156,120,122,145,131,159,221,
        71,126,35,92,253,197,105,157,3,125,11,63,59,191,244,103,238,133,249,90,115,244,206,86,106,170,175,0,153,240,74,81,171,158,188,81,174,75,104,93,50,117,245,250,46,171,119,30,63,
        3,103,226,140,142,93,21,211,99,202,143,79,0,137,170,67,44,153,125,120,208,216,181,149,191,227,104,184,152,10,19,7,28,126,139,7,206,94,245,7,155,221,189,183,98,239,93,249,59,
        238,61,156,155,28,239,33,77,226,238,179,18,123,79,116,155,247,207,255,1,184,142,127,116,231,19,32,159,60,93,71,62,125,201,113,60,177,43,244,238,129,63,61,87,242,228,202,55,107,
        87,229,242,246,197,188,212,232,67,14,174,58,49,152,239,45,157,115,20,143,124,146,255,43,127,7,208,16,12,226,77,137,91,56,198,45,124,164,119,157,188,50,199,255,171,238,204,203,62,
        154,179,226,113,71,149,182,226,39,15,61,123,226,101,158,15,64,73,186,161,56,115,160,27,218,54,45,53,143,150,46,143,11,164,182,1,11,63,142,232,233,133,118,161,221,70,69,183,236,
        147,15,128,140,210,108,101,152,150,222,7,115,206,138,247,21,92,206,86,121,49,163,48,143,61,247,217,147,35,30,254,21,38,188,183,208,224,209,227,58,6,31,61,59,117,231,62,196,249,
        0,72,204,235,129,252,86,24,153,210,188,210,226,11,103,228,85,121,156,169,209,143,61,189,188,238,49,60,230,86,238,49,56,154,10,131,51,218,209,226,53,226,11,151,6,29,252,170,6,
        246,105,207,7,224,19,88,36,50,102,184,108,10,157,58,60,213,21,123,14,247,170,221,123,210,135,154,247,168,106,194,93,3,135,154,235,91,49,92,180,45,222,76,29,15,60,103,52,135,
        57,252,21,48,50,208,80,26,72,175,140,71,90,225,174,129,207,65,201,123,123,165,79,62,28,213,43,111,106,206,75,143,179,121,190,105,244,76,95,120,45,60,103,132,159,62,51,121,79,
        251,242,243,127,128,153,43,252,139,57,179,159,0,163,43,224,41,107,61,209,35,125,226,71,253,208,201,111,101,22,116,35,205,136,215,194,91,117,63,55,156,213,217,221,99,57,214,3,64,
        227,209,225,151,205,159,44,120,198,57,70,119,52,194,123,87,34,45,103,232,241,46,197,244,0,208,88,205,123,7,200,225,42,174,115,18,119,76,135,24,225,226,248,234,233,29,35,158,241,
        239,113,86,48,230,108,245,6,103,159,229,137,15,87,177,102,34,247,249,168,137,195,114,92,181,228,108,56,127,5,64,78,18,102,218,197,225,165,188,226,182,112,184,224,218,125,37,238,152,
        226,10,167,38,220,253,232,161,58,11,110,133,193,209,238,56,26,112,239,65,237,200,142,239,17,63,180,234,235,49,115,180,230,135,251,128,251,239,0,163,129,48,161,217,159,216,191,194,12,
        103,206,205,252,163,187,174,122,72,35,61,123,197,89,174,249,3,208,19,231,224,228,61,205,29,216,145,139,211,28,92,218,159,154,155,187,240,57,142,156,229,136,134,222,229,206,87,64,9,
        90,145,198,186,192,222,37,58,142,70,54,196,224,233,145,184,181,222,194,196,83,159,252,42,151,7,175,10,31,213,188,167,199,35,93,226,126,22,199,220,211,99,231,28,141,189,39,222,91,
        237,95,249,63,0,135,246,11,228,82,188,118,52,118,255,43,125,143,206,51,173,155,253,10,152,54,252,162,196,187,223,148,21,255,222,195,2,150,126,212,117,189,137,157,186,242,217,175,128,
        83,77,22,196,58,168,31,118,65,250,45,168,156,77,111,226,202,27,233,124,60,252,192,179,247,246,192,227,19,160,50,205,1,123,156,30,198,160,61,78,98,228,204,112,38,79,173,230,201,
        218,85,57,103,101,103,126,242,59,118,102,151,183,98,122,122,220,236,203,3,0,193,197,110,64,19,199,209,248,238,120,79,239,26,197,174,243,60,121,119,229,234,175,121,57,167,250,48,147,
        226,209,114,46,30,94,147,190,85,31,121,59,238,115,186,63,113,158,193,181,222,95,241,166,185,235,43,64,230,12,165,33,136,25,144,97,132,61,115,245,250,50,163,230,241,120,101,62,252,
        43,61,53,56,43,190,112,209,226,165,250,76,140,254,97,191,235,1,120,104,244,49,168,134,101,96,14,83,113,87,107,238,137,47,53,118,234,236,212,233,69,93,185,199,202,225,170,158,152,
        112,45,234,112,223,171,207,255,169,254,57,67,206,38,124,171,229,87,0,68,141,237,38,8,28,23,103,118,85,58,247,199,39,251,192,201,58,124,223,225,168,134,206,113,234,213,44,212,208,
        41,215,139,28,173,118,45,248,239,217,231,220,49,215,139,171,28,111,114,237,163,213,243,28,105,29,119,159,173,206,255,1,0,114,96,23,123,188,202,119,237,119,140,57,175,207,62,123,87,
        174,25,197,244,185,195,187,236,253,63,80,228,37,133,100,45,100,212,0,0,0,0,73,69,78,68,174,66,96,130,
    };

    protected static readonly int AsciiCodeStart  = 32;
    protected static readonly int AsciiCodeEnd    = 126;
    protected static readonly int AsciiCodeDelete = AsciiCodeEnd + 1;
    protected static readonly int AsciiCodeReturn = 60; // '\\'
    protected static readonly char[] AsciiCodes = new char[]
    {
        ' ','!','\"','#','$','%','&','\'','(',')','*','+',',','-','.','/',
        '0','1','2','3','4','5','6','7','8','9',':',';','<','=','>','?',
        '@','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O',
        'P','Q','R','S','T','U','V','W','X','Y','Z','[','\\',']','^','_',
        '`','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o',
        'p','q','r','s','t','u','v','w','x','y','z','{','|','}','~',
    };

    protected static int TextBufferID     = -1;
    protected static int TextDataBufferID = -1;

    [System.Serializable]
    public struct TextData
    {
        // NOTE:
        // index.x      = offset.
        // index.y      = length.
        // parameter.xy = position.
        // parameter.z  = charSize.

        public Vector2 index;
        public Vector3 parameter;
        public Color   color;
    }

    private ComputeBuffer textBuffer;
    private ComputeBuffer textDataBuffer;

    private readonly List<int>      textList     = new List<int>();
    private readonly List<TextData> textDataList = new List<TextData>();

    #endregion Field

    #region Method

    protected virtual void Awake()
    {
        if (TextShader.SpriteFontTexture == null)
        {
            TextShader.SpriteFontTexture
            = new Texture2D(TextShader.SpriteFontTextureSize.x,
                            TextShader.SpriteFontTextureSize.y,
                            TextureFormat.ARGB32,
                            false,
                            false)
            {
                filterMode = FilterMode.Point,
                alphaIsTransparency = true
            };

            TextShader.SpriteFontTexture.LoadImage(TextShader.SpriteFontTextureData);
            base.material.SetTexture("_FontTex", TextShader.SpriteFontTexture);
        }

        if (TextShader.TextBufferID < 0)
        {
            TextShader.TextBufferID     = Shader.PropertyToID("_TextBuffer");
            TextShader.TextDataBufferID = Shader.PropertyToID("_TextDataBuffer");
        }
    }

    protected override void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (this.textList.Count != 0)
        {
            this.textBuffer = new ComputeBuffer(this.textList.Count, Marshal.SizeOf(typeof(int)));
            this.textBuffer.SetData(this.textList);

            this.textDataBuffer = new ComputeBuffer(this.textDataList.Count, Marshal.SizeOf(typeof(TextData)));
            this.textDataBuffer.SetData(this.textDataList);

            base.material.SetBuffer(TextShader.TextBufferID,     this.textBuffer);
            base.material.SetBuffer(TextShader.TextDataBufferID, this.textDataBuffer);
        }

        base.OnRenderImage(src, dest);

        if (this.textBuffer != null)
        {
            this.textBuffer.Release();
            this.textDataBuffer.Release();
        }

        this.textList.Clear();
        this.textDataList.Clear();
    }

    protected void OnDestroy()
    {
        if (this.textBuffer != null)
        {
            this.textBuffer.Release();
            this.textBuffer = null;
        }

        if (this.textDataBuffer != null)
        {
            this.textDataBuffer.Release();
            this.textDataBuffer = null;
        }
    }

    public void DrawText(string text, float posX, float posY, float size)
    {
        DrawText(text, posX, posY, size, Color.white);
    }

    public void DrawText(string text, float posX, float posY, float size, Color color)
    {
        int textLength = text.Length;

        this.textDataList.Add(new TextData()
        {
            index     = new Vector2(this.textList.Count, textLength),
            parameter = new Vector3(posX, posY, size),
            color     = color
        });

        for (int i = 0; i < textLength; i++)
        {
            // EX:
            // When the input is "!", the value becomes 33 - 32 = 1.

            int charCode = (int)text[i];

            bool validCode = TextShader.AsciiCodeStart <= charCode
                          && charCode <= TextShader.AsciiCodeEnd;

            charCode = validCode ? charCode - TextShader.AsciiCodeStart
                                 : TextShader.AsciiCodeDelete;

            this.textList.Add(charCode);
        }
    }

    #endregion Method
}