import { Upload, Modal,Button } from 'antd';
import { PlusOutlined,UploadOutlined } from '@ant-design/icons';
import React, { Component, useEffect, useState } from 'react';

function getBase64(file) {
  return new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => resolve(reader.result);
    reader.onerror = error => reject(error);
  });
}

function PicturesWall () {
  // state = {
   
  // };
  // const { previewVisible, previewImage, fileList, previewTitle } = this.state;
 const [fileList , setFileList ] = useState([])

 const handleChange = info => {
      let fileList = [...info.fileList];

      // 1. Limit the number of uploaded files
      // Only to show two recent uploaded files, and old ones will be replaced by the new
      fileList = fileList.slice(-4);

      // 2. Read from response and show file link
      fileList = fileList.map(file => {
        if (file.response) {
          // Component will show file.url as link
          file.url = file.response.url;
        }
        return file;
      });
      setFileList(fileList);
      console.log(fileList)
};

    const uploadButton = (
      <div>
        {/* <PlusOutlined /> */}
        <i class="fa-solid fa-plus"></i> 
        <div style={{ marginTop: 8 }}>Upload</div>
                 
      </div>
    );
    return (
      <div>
        <Upload
          action= 'https://www.mocky.io/v2/5cc8019d300000980a055e76'
          multiple = {true}
          onChange={handleChange}
          fileList={fileList}
        >
                  <Button>Upload</Button>

        </Upload>

      </div>
    );
  }


export default (PicturesWall)