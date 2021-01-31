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
