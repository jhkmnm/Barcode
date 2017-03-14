using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Barcode
{
    /// <summary>
    /// 获取电子秤所秤产品的重量
    /// 默认端口：COM1
    /// 默认数据位：8
    /// 默认波特率9600
    /// </summary>
    public class KCCPort
    {
        #region "Local Property"
        /// <summary>
        /// 端口号
        /// </summary>
        private string strPortName = "COM4";
        /// <summary>
        /// 数据位
        /// </summary>
        private int intDataBits = 8;
        /// <summary>
        /// 波特率
        /// </summary>
        private int intBaudRate = 9600;
        /// <summary>
        /// 串口数据访问类
        /// </summary>
        private SerialPort comPort = new SerialPort();
        /// <summary>
        /// 电子秤类型
        /// </summary>
        private string strType = "XK3190-A1";

        private int mateCount = 5;
        private int tryCount = 5;
        #endregion

        public KCCPort()
        {
            ReadConfigMsg();
        }

        /// <summary>
        /// 初始化串口控件
        /// </summary>
        /// <param name="PortName">端口号</param>
        /// <param name="DataBits">数据位</param>
        /// <param name="BaudRate">波特率</param>
        /// <returns></returns>
        public bool initComPort(string PortName)
        {
            try
            {
                comPort.PortName = PortName;
                comPort.DataBits = intDataBits;
                comPort.BaudRate = intBaudRate;
                comPort.ReadTimeout = 3000;
                comPort.Parity = Parity.None;
                comPort.StopBits = StopBits.One;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string ExtractWeight(string str)
        {
            var weights = str.Split('\r');
            string def = "";
            int count = 0;

            foreach(string weight in weights)
            {
                if(weight != def)
                {
                    count = 0;
                }
                else if(weight.EndsWith("R"))
                {
                    count++;
                }
                def = weight;

                if(count == mateCount)
                {
                    break;
                }
            }

            return count == mateCount ? def.TrimEnd('R') : "error";
        }

        public string ProductWeight()
        {
            try
            {
                switch(strType)
                {
                    case "XK3190-A1":
                        if (!comPort.IsOpen)
                            comPort.Open();
                        return comPort.ReadExisting();
                    default:
                        return "秤配置错误";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void ClosePort()
        {
            if (comPort.IsOpen)
                comPort.Close();
        }

        /// <summary>
        /// 读取电子秤的配置信息
        /// </summary>
        /// <returns></returns>
        private void ReadConfigMsg()
        {
            try
            {
                //需求 #8180 系统本地配置管理 童荣辉增加 20131108
                //if (UTIL.LocalConfig.IsEnabled)
                //{
                //    strType = UTIL.LocalConfig.GetValue(UTIL.LocalConfig.ConstNodeKey.KCCTYPE);
                //    strPortName = UTIL.LocalConfig.GetValue(UTIL.LocalConfig.ConstNodeKey.KCPortName);
                //}
                //else
                //{
                //    FileStream fs = new FileStream("Config/LocalConfig.Ini", FileMode.Open);
                //    try
                //    {
                //        StreamReader m_streamReader = new StreamReader(fs);
                //        string strType1 = m_streamReader.ReadLine();
                //        if (strType1 != "")
                //        {
                //            strType = strType1.Substring(strType1.IndexOf("=") + 1);
                //        }
                //        string strPortName1 = m_streamReader.ReadLine();
                //        if (strPortName1 != "")
                //        {
                //            strPortName = strPortName1.Substring(strPortName1.IndexOf("=") + 1);
                //        }
                //        m_streamReader.Close();
                //        UTIL.EventLogProcess.LogInformationEvent("电子称" + strType + "-" + strPortName);
                //    }
                //    catch
                //    { }
                //    fs.Close();
                //    fs.Dispose();
                //}
            }
            catch (Exception ex)
            {
                //UTIL.MsgTool.ShowMessage("读取配置信息失败！"+ex.Message);
            }
        }

        /// <summary>
        /// 读取电子秤的配置信息
        /// </summary>
        /// <returns></returns
        public string ReadConfigMessage()
        {
            string strResult = "";
            try
            {
                FileStream fs = new FileStream("Config/LocalConfig.Ini", FileMode.Open);
                try
                {
                    StreamReader m_streamReader = new StreamReader(fs);
                    string strType1 = m_streamReader.ReadLine();
                    if (strType1 != "")
                    {
                        strResult = strType1.Substring(strType1.IndexOf("=") + 1);
                    }
                    m_streamReader.Close();
                }
                catch
                { }
                fs.Close();
                fs.Dispose();
            }
            catch (Exception ex)
            {
                //UTIL.MsgTool.ShowMessage("读取配置信息失败！" + ex.Message);
            }
            return strResult;
        }
        /// <summary>
        /// 把电子秤的配置写到配置文件中
        /// </summary>
        /// <param name="strKccType"></param>
        /// <returns></returns>
        public bool WriteConfigMsg(string strKccType)
        {
            string strPath = System.IO.Directory.GetCurrentDirectory() + "\\Config";
            bool blnResult = false;
            try
            {
                if (!Directory.Exists(strPath))
                {
                    Directory.CreateDirectory(strPath);
                }
                DelFile(strPath + "\\LocalConfig.Ini");
                FileStream fs = new FileStream(strPath + "\\LocalConfig.Ini", FileMode.OpenOrCreate);
                StreamWriter m_streamWrite = new StreamWriter(fs);
                m_streamWrite.WriteLine(strKccType);
                m_streamWrite.Flush();
                m_streamWrite.Close();
                fs.Close();
                fs.Dispose();
                return blnResult;
            }
            catch (Exception ex)
            {
                //UTIL.MsgTool.ShowMessage("写入电子秤配置信息失败，请确认！" + ex.Message);
                return blnResult;
            }
        }

        private bool DelFile(string strFileName)
        {
            try
            {
                FileInfo fi = new FileInfo(strFileName);
                fi.Delete();
                fi = null;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string splitStrResult(string strValue)
        {
            string strC = "";
            try
            {
                string[] arrStr = strValue.Split('+');
                for (int i = 1; i < arrStr.Length; i++)
                {
                    if (arrStr[i].Length == 11)
                    {
                        strC = arrStr[i].Substring(0, 8);
                        break;
                    }
                }
            }
            catch
            { }
            return strC;
        }
    }

    public class ReturnResult
    {
        public bool IsError { get; set; }
        public string Value { get; set; }
    }
}
