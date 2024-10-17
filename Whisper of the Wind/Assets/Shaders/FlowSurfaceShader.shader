Shader "Custom/FlowSurfaceShader"
{
    Properties
    {
        _MainTex ("Sprite Texture", 2D) = "white" {}   // Текстура спрайта
        _Color ("Color Tint", Color) = (1,1,1,1)      // Цветовой оттенок (настраивается в материале)
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        // LOD 200

        // Blend SrcAlpha OneMinusSrcAlpha // Режим альфа-смешивания для прозрачности
        // ZWrite Off // Отключаем запись в буфер глубины для прозрачных объектов
        // Cull Off // Отключаем отсечение граней, чтобы видеть обе стороны спрайта

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows alpha
        // #pragma target 3.0

        sampler2D _MainTex;
        fixed4 _Color;

        struct Input
        {
            float2 uv_MainTex; // UV-координаты для текстуры
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float2 uv = IN.uv_MainTex;
            float sinValue = sin(uv.x * 6.28 + _Time.y);
            sinValue *= 0.5;
            sinValue += 0.5;
            sinValue *= uv.y;
            uv.y += sinValue;
            fixed4 c = tex2D(_MainTex, uv) * (1,1,1);
            if (c.a < 0.01) discard; // Пропускаем пиксели с минимальной прозрачностью

            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Transparent/Cutout/VertexLit"
}
