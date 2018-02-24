/*
Copyright (c) 2003-2012, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

(function () {
    var youtubeCmd = { exec: function (editor) { editor.openDialog('youtube'); return } };
    CKEDITOR.plugins.add('youtube', { lang: ['en', 'uk'], requires: ['dialog'],
        init: function (editor) {
            var commandName = 'youtube'; editor.addCommand(commandName, youtubeCmd);
            editor.ui.addButton('Youtube', { label: editor.lang.youtube.button, command: commandName, icon: this.path + "images/youtube.png" });
            CKEDITOR.dialog.add(commandName, CKEDITOR.getUrl(this.path + 'dialogs/youtube.js'))
        } 
    })
})();

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    //config.language = 'fr';
    // config.uiColor = '#AADC6E';
    //config.Skin = "v2";
    config.height = '350';

    //    ['FitWindow', 'Source'],
    //	['Cut', 'Copy', 'Paste', 'PasteText', 'PasteWord'],
    //	['Undo', 'Redo', '-', 'Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'],
    //	['Image', 'Flash', 'Table', 'Rule', 'Smiley', 'SpecialChar', 'PageBreak'],
    //	'/',
    //	['Bold', 'Italic', 'Underline', 'StrikeThrough', '-', 'Subscript', 'Superscript'],
    //	['OrderedList', 'UnorderedList', '-', 'Outdent', 'Indent'],
    //	['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyFull'],
    //	['Link', 'Unlink', 'Anchor'],
    //	['TextColor', 'BGColor'],
    //	'/',
    //	['Style', 'FontFormat'], ['FontName', 'FontSize', 'About']		// No comma for the last row.



    config.toolbar = 'Full';
    config.extraPlugins = 'youtube';

    config.toolbar_Full =
[
    { name: 'tools', items: ['Source', 'Maximize', 'ShowBlocks'] },
    { name: 'clipboard', items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo', '-', 'Find', 'Replace', ] },
    { name: 'insert', items: ['Image', 'Flash', 'Youtube', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', ] },
    '/',
    { name: 'basicstyles', items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'RemoveFormat'] },
    { name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', ] },
    { name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
    '/',
    { name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
    { name: 'colors', items: ['TextColor', 'BGColor'] }

];
    config.toolbar_Basic =
[
    ['Source', '-', 'Bold', 'Italic']
];

};
