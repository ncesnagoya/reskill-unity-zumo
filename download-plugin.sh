#!/bin/bash

# ディレクトリの作成
mkdir -p Assets/Plugin

echo "注意: このスクリプトはプライベートリポジトリからプラグインを取得しようとしています。"
echo "   認証なしでは動作しない可能性が高いです。"
echo "----------------------------------------"

# プラグインリリースページのURLを表示
REPO_URL="https://github.com/ncesnagoya/reskill-unity-zumo"
RELEASE_URL="$REPO_URL/releases"
DOWNLOAD_URL="$REPO_URL/releases/download/v1.0.0/Plugin.zip"

echo "リポジトリURL: $REPO_URL (プライベートリポジトリ)"
echo "リリースページ: $RELEASE_URL"
echo "ダウンロードURL: $DOWNLOAD_URL"
echo "----------------------------------------"

echo "アクセス権限の確認中..."
curl -I $REPO_URL 2>/dev/null | grep "HTTP/" | head -1

# プラグインのダウンロード
echo "プラグインをダウンロード中..."
echo "（注: 認証が必要なためブラウザからのダウンロードをお勧めします）"
curl -L $DOWNLOAD_URL -o plugin.zip

# ダウンロード成功の確認
if [ $? -ne 0 ] || [ ! -s plugin.zip ]; then
  echo "----------------------------------------"
  echo "エラー: プラグインのダウンロードに失敗しました。"
  echo "これはプライベートリポジトリであるため、期待される動作です。"
  echo ""
  echo "代替方法:"
  echo "1. ブラウザで $DOWNLOAD_URL にアクセスし、アカウントでログインしてダウンロード"
  echo "2. ダウンロードしたファイルを Assets/Plugin フォルダに解凍してください"
  echo "----------------------------------------"
  # ゼロバイトのファイルを削除
  rm -f plugin.zip
  exit 1
fi

# 以下はダウンロードが成功した場合の処理
# ファイルサイズの確認
FILE_SIZE=$(du -k "plugin.zip" | cut -f1)
echo "ダウンロードしたファイルサイズ: ${FILE_SIZE}KB"

# プラグインの解凍
echo "プラグインを解凍中..."
unzip -o plugin.zip -d Assets/Plugin

# 解凍成功の確認
if [ $? -ne 0 ]; then
  echo "----------------------------------------"
  echo "エラー: プラグインの解凍に失敗しました。"
  echo "ダウンロードされたファイルが有効なZIPファイルではありません。"
  echo "ブラウザから手動でダウンロードし、Assets/Pluginフォルダに展開してください。"
  echo "----------------------------------------"
  exit 1
fi

# 一時ファイルの削除
rm plugin.zip

echo "プラグインのインストールが完了しました！" 