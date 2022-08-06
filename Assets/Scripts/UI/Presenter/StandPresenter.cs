using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandPresenter : UIPresenter
{
    [SerializeField] StandView _view;

    string _talker;
    FaceType _faceType;
    PositionType _positionType;

    public void SetPosition(PositionType type)
    {
        _positionType = type;
    }

    public void SetTaker(string talker, FaceType type)
    {
        _talker = talker;
        _faceType = type;
    }

    public override void Process()
    {
        UIManager ui = GameManager.Instance.GetManager<UIManager>(nameof(UIManager));

        CharaModelData charaModel = ui.GetCharaModel(_talker);
        Sprite sprite = charaModel.GetFaceData(_faceType);

        _view.SetView(sprite, _positionType);
    }
}
