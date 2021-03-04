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
