# Zumo Robot Unity Simulator

このプロジェクトは、Zumoロボットのシミュレーション環境をUnityで実現したものです。

## 概要

Zumoロボットの物理シミュレーションを行い、以下の機能を提供します：

- モーター制御（左右独立した差動駆動）
- IMUセンサー（加速度、ジャイロ、磁気センサー）
- 反射光センサー
- LEDコントロール
- 物理シミュレーション（衝突検知など）

## セットアップ

1. このリポジトリをクローン
2. [Plugin.zip](https://example.com/plugin/download/link) をダウンロード
3. `Assets/Plugin` フォルダに解凍したファイルを配置
4. Unity 2022.3.16f1 以上で開く

## プロジェクト構造

```
Assets/
├── Plugin/          # プラグインファイル（別途ダウンロード必要）
├── Scripts/         # メインスクリプト
│   ├── HakoAssets/ # 箱庭アセット関連
│   └── HakoRoboParts/ # ロボットパーツ実装
├── Model/           # 3Dモデル
├── Prefab/         # プレハブ
└── Scenes/         # シーンファイル
```

## 主要コンポーネント

### Zumoロボット制御

- `ZumoModelController`: ロボット全体の制御
- `ZumoMotorController`: モーター制御（差動駆動）
- `ZumoImu`: IMUセンサー実装
- `ZumoReflectanceSensor`: 反射光センサー実装
- `ZumoLed`: LED制御

### テストドライバー

デバッグ・テスト用の各種ドライバーが用意されています：
dis
- `ZumoMotorControllerTestDriver`: キーボードでモーター制御
- `ZumoImuTestDriver`: IMUセンサー値表示
- `ZumoLedTestDriver`: LED制御テスト
- `ZumoReflectSensorTestDriver`: 反射光センサーテスト

## 使用方法

1. シーンを開く
2. Play モードで実行
3. テストドライバーを使用してロボットを制御:
   - ↑↓: 前後移動
   - ←→: 回転
   - Space: 停止
   - G: LED ON/OFF

## 注意事項

- Plugin フォルダは gitignore されているため、別途ダウンロードが必要です
- Unity のバージョンは 2022.3.16f1 以上を推奨
- 物理演算のスケールは実機の約10倍で実装されています