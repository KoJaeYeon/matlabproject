using System.Xml;
using UnityEngine;

public class XmlTest : MonoBehaviour
{
    void Start()
    {
        CreateXml();
    }

    void CreateXml()
    {
        XmlDocument xmlDoc = new XmlDocument();

        // Xml�� �����Ѵ�(xml�� ������ ���ڵ� ����� �����ش�.)
        xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

        // ��Ʈ ��� ����
        XmlNode root = xmlDoc.CreateNode(XmlNodeType.Element, "CharacterInfo", string.Empty);
        xmlDoc.AppendChild(root);

        // �ڽ� ��� ����
        XmlNode child = xmlDoc.CreateNode(XmlNodeType.Element, "Character", string.Empty);
        root.AppendChild(child);

        // �ڽ� ��忡 �� �Ӽ� ����
        XmlElement name = xmlDoc.CreateElement("Name");
        name.InnerText = "wergia";
        child.AppendChild(name);

        XmlElement lv = xmlDoc.CreateElement("Level");
        lv.InnerText = "1";
        child.AppendChild(lv);

        XmlElement exp = xmlDoc.CreateElement("Experience");
        exp.InnerText = "45";
        child.AppendChild(exp);

        xmlDoc.Save("./Assets/Resources/Character.xml");
    }
}