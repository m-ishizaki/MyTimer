using System;
using System.Collections.Generic;
using System.Text;

namespace MyTimer
{
    // アラートダイアログ表示メッセージのパラメーター
    class AlertParameter
    {
        // 表示末うアラートダイアログのタイトルを取得または設定する
        public string Title { get; set; }
        // 表示末うアラートダイアログのメッセージを取得または設定する
        public string Message { get; set; }
        // 表示末うアラートダイアログの OK ボタンのテキストを取得または設定する
        public string Accept { get; set; }
        // 表示末うアラートダイアログのキャンセルボタンのテキストを取得または設定する
        public string Cancel { get; set; }
        // 表示末うアラートダイアログの選択時に呼ばれる処理を取得または設定する
        public Action<bool> Action { get; set; }
    }
}
