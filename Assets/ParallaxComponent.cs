using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class            ParallaxComponent : MonoBehaviour
{
    public float        backgroundWidth;
    public float        parallaxSpeed;

    private Transform   cameraTransform;
    private Transform[] layers;
    private float       viewZone = 16.0f;
    private int         leftIndex;
    private int         rightIndex;
    private float       lastCameraX;

	private void        Start()
    {
		this.cameraTransform = Camera.main.transform;
        this.lastCameraX = this.cameraTransform.position.x;
        this.layers = new Transform[this.transform.childCount];

        for (int index = 0; index < this.transform.childCount; ++index)
            this.layers[index] = this.transform.GetChild(index);

        this.leftIndex = 0;
        this.rightIndex = this.layers.Length - 1;
	}

    private void        Update()
    {
        float           deltaX = this.cameraTransform.position.x - this.lastCameraX;

        this.transform.position += Vector3.right * (deltaX * this.parallaxSpeed);
        this.lastCameraX = this.cameraTransform.position.x;

        if (this.cameraTransform.position.x < (this.layers[this.leftIndex].transform.position.x + this.viewZone))
            this.ScrollLeft();
        if (this.cameraTransform.position.x > (this.layers[this.rightIndex].transform.position.x - this.viewZone))
            this.ScrollRight();
    }
    
    private void        ScrollLeft()
    {
        this.layers[this.rightIndex].position = Vector3.right * (this.layers[this.leftIndex].position.x - this.backgroundWidth);

        this.leftIndex = this.rightIndex;
        this.rightIndex--;
        if (this.rightIndex < 0)
            this.rightIndex = this.layers.Length - 1;
    }

    private void        ScrollRight()
    {
        this.layers[this.leftIndex].position = Vector3.right * (this.layers[this.rightIndex].position.x + this.backgroundWidth);

        this.rightIndex = this.leftIndex;
        this.leftIndex++;
        if (this.leftIndex == this.layers.Length)
            this.leftIndex = 0;
    }
}
