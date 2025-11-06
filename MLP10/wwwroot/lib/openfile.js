function BlazorDownloadFile(filename, content) {
    // content ожидается как byte[] (Blazor автоматически преобразует)
    const uint8Array = new Uint8Array(content);
    const blob = new Blob([uint8Array], { type: "application/octet-stream" });
    const exportUrl = URL.createObjectURL(blob);
    const a = document.createElement("a");
    document.body.appendChild(a);
    a.href = exportUrl;
    a.download = filename;
    a.target = "_self";
    a.click();
    URL.revokeObjectURL(exportUrl);
    a.remove();
}