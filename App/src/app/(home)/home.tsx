import Content from "@/components/content/content";
import UpperBar from "@/components/upperbar/upperbar";

async function Home() {
  return (
    <div className="allScreen">
      <UpperBar></UpperBar>
      <Content></Content>
    </div>
  );
}

export default Home;