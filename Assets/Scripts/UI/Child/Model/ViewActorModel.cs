using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ViewActorModel
{
    class ImageData
    {
        public string User { get; private set; }
        public Vector2 Size { get; private set; }
        public bool IsUsing { get; private set; }
        public Image Image { get; private set; }

        public void CreateImage(Transform parent)
        {
            Image = new GameObject("Sorce").AddComponent<Image>();
            Image.transform.SetParent(parent);
        }
    }

    public ViewActorModel(int actorCount, Transform parent)
    {
        _imageDataList = new List<ImageData>();

        for (int index = 0; index < actorCount; index++)
        {
            ImageData data = new ImageData();
            data.CreateImage(parent);

            _imageDataList.Add(data);
        }
    }

    List<ImageData> _imageDataList;

    public void FindData(string user)
    {
        if (_imageDataList.All(i => !i.IsUsing))
        {
            SetData(user);
            return;
        }
    }

    void SetData(string user)
    {

    }
}
