2021/04/02 21:07
★演奏開始モーションにて演奏開始仮モーション実装とパーティクル演出追加
・蝶オブジェクトとパーティクルオブジェクトを追加など
Assets\Scenes\02_Stage001.unity
・蝶のグループオブジェクトの有効無効切り替えと位置調整
Assets\Scripts\ScPlayedTrigger.cs
・カットシーンへアニメーショントラック制御スクリプトを追加
Assets\Timelines\StartPlayingDirect.playable
・蝶パーティクルのプレハブを作成
Assets\Prefabs\SoulArchive.prefab
・蝶位置のオフセット調整オブジェクトを作成
Assets\Scripts\ScAgehaOffSet.cs
・蝶カットシーンのトラック開始オフセット調整スクリプトを作成
Assets\Scripts\ScTimelineTrackProperty.cs
・パーティクル追加（URP）
ProjectSettings\URPProjectSettings.asset

2021/03/20 21:00
★演奏トリガーに触れると演奏開始カメラ演出
・ゲームステージ画面にて、演出カメラ設置など
Assets\Scenes\02_Stage001.unity
・プレイヤー自動移動ロジック追加と操作ロジックの一部修正
Assets\Scripts\ScCharacterController.cs
・トリガー処理後に演奏開始カットシーンの起動とFTP視点へ切り替え
Assets\Scripts\ScPlayedTrigger.cs
・演奏開始アニメーション
Assets\Animations\StartPlaying_Cut1.anim
Assets\Animations\StartPlaying_Cut1.controller
Assets\Animations\StartPlaying_Cut2.anim
Assets\Animations\StartPlaying_Cut2.controller
Assets\Animations\StartPlaying_Cut3.anim
Assets\Animations\StartPlaying_Cut3.controller
Assets\Animations\StartPlaying_Cut4.anim
Assets\Animations\StartPlaying_Cut4.controller
・トリガーのプレハブを作成
Assets\Prefabs\PlayedTrigger.prefab
・演奏開始カットシーンを作成
Assets\Timelines\StartPlayingDirect.playable
ProjectSettings\TimelineSettings.asset

2021/03/06 15:37
★プレイヤーの移動ロジック修正と視点切り替え
・プレイヤー移動アニメーションを調整
Assets\Animations\PlayerAnimatorController.controller
・演奏トリガーの配置やその他のオブジェクト調整
Assets\Scenes\02_Stage001.unity
・カメラの視点に合わせてキャラクターの移動方向を調整
Assets\Scripts\ScCharacterController.cs
・RスティックのInputManager定義名を追加
Assets\Scripts\Commons\CsNormalLevelDesignOfCommon.cs
・InputManagerにRスティックの入力情報を追加してAxis系の入力範囲を調整
ProjectSettings\InputManager.asset
・カメラ操作スクリプトを作成
Assets\Scripts\ScCameraWork.cs
・FPS視点切り替えのスクリプトを作成
Assets\Scripts\ScFPSCController.cs
・触れるとFPS視点へ切り替えるトリガーオブジェクトに対するスクリプトを作成
Assets\Scripts\ScPlayedTrigger.cs

2021/03/04 22:19
★プレイヤーの移動ロジック修正と楽器装備
・ギター3Dデータをコミット対象から除外
.gitignore
・プレイヤーオブジェクト、楽器オブジェクトの調整
Assets\Scenes\02_Stage001.unity
・キャラクターの操作制御スクリプトのクリーンアップ
Assets\Scripts\ScCharacterController.cs
・定数クラスにユニティちゃんオブジェクト名を追加
Assets\Scripts\Commons\CsNormalLevelDesignOfCommon.cs
・Cinemachineを追加
Packages\manifest.json
Packages\packages-lock.json
・楽器の位置調整制御スクリプトを作成
Assets\Scripts\ScHoldInstrument.cs
・TransformBeanのBeanを作成
Assets\Scripts\Beans\CsTransformBean.cs

2021/01/31 21:20
★StandardAsetとユニティちゃん追加と操作ロジック作成
・StandardAsetとユニティちゃんをコミット対象から除外
.gitignore
・操作処理の追加
ProjectSettings\ProjectSettings.asset
UserSettings\EditorUserSettings.asset
・操作アニメーションを追加
Assets\Animations\PlayerAnimatorController.controller
・メインゲーム画面にて、キャラクター配置など
Assets\Scenes\02_Stage001.unity
・新規スクリプトファイル作成時にUTF-8（BOM）変換
Assets\Editor\AssetPostprocessUTF8Encode.cs
・キャラクター操作制御スクリプトクラスを作成
Assets\Scripts\ScCharacterController.cs
・定数クラスを作成
Assets\Scripts\Commons\CsNormalLevelDesignOfCommon.cs

2021/01/31 12:31
★新規プロジェクト作成
・コミット対象設定ファイルの追加
.gitignore
・新規プロジェクの追加
UnityProjectBeatReboot\*
