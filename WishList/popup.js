document.addEventListener("DOMContentLoaded", function() {
    // フォーム送信時の処理
    const registrationForm = document.getElementById("registrationForm");
    const urlInput = document.getElementById("url");
    const itemInput = document.getElementById("item");
    const registeredItemsList = document.getElementById("registeredItems"); // ここでregisteredItemsListを定義

    // データを保存するための関数,関数を作成function
    function saveData(url, item) {
        chrome.storage.sync.get(["registeredData"], function(data) {
            const registeredData = data.registeredData || [];

            // 新しいデータを追加
            registeredData.push({ url, item });

            chrome.storage.sync.set({ "registeredData": registeredData }, function() {
                // 保存が完了したら何か特別な処理を行う場合はここに記述
            });
        });
    }

    // 登録されたデータを表示するコード,関数を作成function
    function displayData() {
        chrome.storage.sync.get(["registeredData"], function(data) {
            const registeredData = data.registeredData || [];

            registeredItemsList.innerHTML = ""; // リストをクリア

            for (let i = 0; i < registeredData.length; i++) {
                const listItem = document.createElement("li");
                
                // アイテムをリンクとして表示
                const link = document.createElement("a");
                link.href = registeredData[i].url;
                link.textContent = "アイテム: " + registeredData[i].item;
                link.target = "_blank"; // リンクを新しいタブで開く

                listItem.appendChild(link);
                
                // 削除ボタンの追加（前回のコードを流用）
                const deleteButton = document.createElement("button");
                deleteButton.textContent = "削除";
                deleteButton.addEventListener("click", function() {
                    registeredData.splice(i, 1);
                    chrome.storage.sync.set({ "registeredData": registeredData }, function() {
                        displayData();
                    });
                });

                listItem.appendChild(deleteButton);
                registeredItemsList.appendChild(listItem);
            }
        });
    }

    displayData(); // 初期表示

    registrationForm.addEventListener("submit", function(event) {
        event.preventDefault(); // フォームの通常の送信を防止

        const url = urlInput.value;
        const item = itemInput.value;

        if (url && item) {
            // データを保存
            saveData(url, item);
            displayData();

            // 入力フィールドをクリア
            urlInput.value = "";
            itemInput.value = "";
        }
    });
});
