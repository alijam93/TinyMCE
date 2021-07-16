createQuill = (
    quillElement, toolBar, readOnly,
    placeholder, theme, debugLevel) => {

    Quill.register('modules/blotFormatter', QuillBlotFormatter.default);

    var options = {
        debug: debugLevel,
        modules: {
            toolbar: toolBar,
            blotFormatter: {}
        },
        placeholder: placeholder,
        readOnly: readOnly,
        theme: theme
    };

    new Quill(quillElement, options);
};

getQuillContent = (quillElement) => {
    return JSON.stringify(quillElement.__quill.getContents());
};

getQuillText = (quillElement) => {
    return quillElement.__quill.getText();
};

getQuillHTML = (quillElement) => {
    return quillElement.__quill.root.innerHTML;
};

loadQuillContent = (quillElement, quillContent) => {
    content = JSON.parse(quillContent);
    return quillElement.__quill.setContents(content, 'api');
};

loadQuillHTMLContent = (quillElement, quillHTMLContent) => {
    return quillElement.__quill.root.innerHTML = quillHTMLContent;
};

enableQuillEditor = (quillElement, mode) => {
    quillElement.__quill.enable(mode);
};

insertQuillImage = (quillElement, imageURL) => {
    var Delta = Quill.import('delta');
    editorIndex = 0;

    if (quillElement.__quill.getSelection() !== null) {
        editorIndex = quillElement.__quill.getSelection().index;
    }

    return quillElement.__quill.updateContents(
        new Delta()
            .retain(editorIndex)
            .insert({ image: imageURL },
                { alt: imageURL }));
};
