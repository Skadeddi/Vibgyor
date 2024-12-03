using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class InvertRenderFeature : ScriptableRendererFeature
{
    [SerializeField] private Shader shader;
    private Material material;
    private InvertRenderPass irp;

    public override void Create()
    {
        if(shader == null)
        {
            return;
        }

        material = CoreUtils.CreateEngineMaterial(shader);
        irp = new InvertRenderPass(material);

        irp.renderPassEvent = RenderPassEvent.AfterRenderingSkybox;
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        if(renderingData.cameraData.cameraType == CameraType.Game)
        {
            renderer.EnqueuePass(irp);
        }
    }

}
