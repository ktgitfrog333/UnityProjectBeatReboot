using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Linq;

/// <summary>
/// タイムライン内のトラック制御
/// </summary>
public class ScTimelineTrackProperty : MonoBehaviour
{
    /// <summary>蝶のカットシーンからタイムライン取得用</summary>
    [SerializeField] private PlayableDirector _director;
    /// <summary>蝶グループ位置</summary>
    public ScAgehaOffSet _agehaPositions { get; set; }

    /// <summary>
    /// 蝶の位置オフセットを調整する
    /// </summary>
    public void AgehaPositionOffSet()
    {
        var tracks = (_director.playableAsset as TimelineAsset).GetOutputTracks();
        var animationTrackBlue = tracks.FirstOrDefault(x => x.name == "BlueTrack") as AnimationTrack;
        animationTrackBlue.position = _agehaPositions._agehaBlue;
        var animationTrackGreen = tracks.FirstOrDefault(x => x.name == "GreenTrack") as AnimationTrack;
        animationTrackGreen.position = _agehaPositions._agehaGreen;
        var animationTrackOrange = tracks.FirstOrDefault(x => x.name == "OrangeTrack") as AnimationTrack;
        animationTrackOrange.position = _agehaPositions._agehaOrange;
        var animationTrackPurple = tracks.FirstOrDefault(x => x.name == "PurpleTrack") as AnimationTrack;
        animationTrackPurple.position = _agehaPositions._agehaPurple;
        var animationTrackRed = tracks.FirstOrDefault(x => x.name == "RedTrack") as AnimationTrack;
        animationTrackRed.position = _agehaPositions._agehaRed;
    }
}
