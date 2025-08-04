// TextListEditorWindow.cs
using UnityEngine;
using UnityEditor;

namespace Tech.C
{
    public class TextListEditorWindow : EditorWindow
    {
        private CommentData commentData; // アタッチするSO
        private string inputText = ""; // 入力されたテキスト

        [MenuItem("Tools/Text List Editor")]
        public static void OpenWindow()
        {
            GetWindow<TextListEditorWindow>("Text List Tool");
        }

        private void OnGUI()
        {
            GUILayout.Label("Text List Editor", EditorStyles.boldLabel);

            // SOフィールド
            commentData = (CommentData)EditorGUILayout.ObjectField("Target SO", commentData, typeof(CommentData), false);

            // 入力欄
            GUILayout.Label("Input Text (use Enter to separate lines)");
            inputText = EditorGUILayout.TextArea(inputText, GUILayout.MinHeight(100));

            // 追加ボタン
            if (GUILayout.Button("Add Lines to SO"))
            {
                AddLinesToSO();
            }

            // SOが設定されていれば、内容表示
            if (commentData != null)
            {
                GUILayout.Label("Current Lines in SO:");
                foreach (var line in commentData.comments)
                {
                    GUILayout.Label("- " + line);
                }
            }
        }

        private void AddLinesToSO()
        {
            if (commentData == null)
            {
                Debug.LogWarning("No ScriptableObject assigned.");
                return;
            }

            // テキストを行ごとに分割
            string[] newLines = inputText.Split(new[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);

            // SOに追加
            foreach (var line in newLines)
            {
                string trimmed = line.Trim();
                if (!string.IsNullOrEmpty(trimmed))
                {
                    Undo.RecordObject(commentData, "Add Line to CommentData");
                    commentData.comments.Add(trimmed);
                    EditorUtility.SetDirty(commentData);
                }
            }

            // 入力欄をリセット
            inputText = "";
        }
    }
}
